    Decimal tempSal;
    string sal = Console.ReadLine();
    if (Decimal.TryParse(sal, out tempSal))
    {
        customer.Salary = tempSal;
    }
    else
    {
        // user entered bad data
    }
