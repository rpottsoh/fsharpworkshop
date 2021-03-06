﻿module Functions

open Types
open System

let tryPromoteToVip (customer, spendings) =
    if spendings > 100M then { customer with IsVip = true }
    else customer

let getSpendings customer =
    if customer.Id % 2 = 0 then (customer, 120M)
    else (customer, 80M)

let increaseCredit condition customer =
    if condition customer then { customer with Credit = customer.Credit + 100M }
    else { customer with Credit = customer.Credit + 50M }

let vipCondition customer = customer.IsVip

let increaseCreditUsingVip = increaseCredit vipCondition

let upgradeCustomer = getSpendings >> tryPromoteToVip >> increaseCreditUsingVip