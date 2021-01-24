    var result = Database.Client.Context.CheckRegister
    .Where(...)
    .GroupBy(cr => cr.CheckNumber,
    // ResultSelector: take every key (which we call checkNumber)
    // and all CheckRegisters with this CheckNumber
    // to make one new object:
    (checkNumber, checkRegistersWithThisCheckNumber) => new
    { 
        CheckNumber = key, 
        // for Employees: Select property Employee, and convert them to a List
        Employees = checkRegistersWithThisCheckNumber
                    .Select(checkRegister => checkRegister.Employee)
                    .ToList(),
        // Amounts: select the Amounts and Sum
        Amount = checkRegistersWithThisCheckNumber
                     .Select(checkRegister => checkRegister.Amount)
                     .Sum(),
        });
