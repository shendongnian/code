            List<string> employees = new List<string>();
            employees.Add("e1");
            employees.Add("e2");
            employees.Add("e3");
            string employeesString = "'" + employees.Aggregate((x, y) => x + "','" + y) + "'";
            Console.WriteLine(employeesString);
            Console.ReadLine();
