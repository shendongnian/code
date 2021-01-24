            float totalOwed = 0;
            foreach(Employee e in employees)
            {
                totalOwed += e.CalculatePay();
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("");
            Console.WriteLine($"The total amount of money owed by the company to Employees is: {totalOwed})";
As a side note, storing money in float or double is a BAAAD idea. Use `decimal` for that.
