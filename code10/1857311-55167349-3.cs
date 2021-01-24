    // Take the complete table of CheckRegisters:
    Database.Client.Context.CheckRegister
    // from every checkRegister in this table (every row),
    // keep only those checkRegisters that have a CheckingAccount value equal to account
    // and a CheckDate value betwen fromData and toDate
    // and a value for property Void equalt to "N"
    .Where(checkRegister => checkRegister.CheckingAccount == account 
                         && checkRegister.CheckDate >= fromDate 
                         && checkRegister.CheckDate <= toDate 
                         && checkRegister.Void == "N" )
    // Group all remaining CheckRegisters into groups with same checkNumber
    // Each group will have a property Key which has the value of the common CheckNumber
            .GroupBy(cr => cr.CheckNumber,
               // ElementSelector: from every CheckRegister put only the amount in each grouop 
               checkRegister => checkRegister.Amount,
               // ResultSelector: take every key (which we call checkNumber)
               // and all Amounts of all CheckRegisters with this CheckNumber
               // to make one new object:
               (checkNumber, amountsFromCheckRegistersWithThisCheckNumber) => new
               { 
                    CheckNumber = key, 
                    // To calculate property Amount: sum all amountsFromCheckRegistersWithThisCheckNumber
                    Amount = amountsFromCheckRegistersWithThisCheckNumber.Sum(),
               })
    // By now you have a sequence of objects, each with two properties:
    // CheckNumber: a checkNumber used in the CheckRegisters that were left after the Where
    // Amount: the sum of all Amounts of all CheckRegisters that have this CheckNumber
    
    // Finally you do some Ordering, and convert the resulting elements into a list
    .OrderBy(groupedItem => groupedItem.CheckNumber)
    .ToListAsync();
         
