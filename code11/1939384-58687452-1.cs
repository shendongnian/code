    float totalOwed = 0;
    foreach(Employee e in employees)
    {
          totalOwed += e.CalculatePay();
          Console.WriteLine(e.ToString());
    }
    Console.WriteLine("");
    Console.WriteLine($"The total amount of money owed by the company to Employees is: {totalOwed})";
