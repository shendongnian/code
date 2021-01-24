     new List<Employee> {
                new Employee { EmployeeNumber = 1, Name = "A", Department = "D1", MonthlyScore = 10  },
                new Employee { EmployeeNumber = 2, Name = "B", Department = "D2", MonthlyScore = 40  },
                new Employee { EmployeeNumber = 3, Name = "C", Department = "D2", MonthlyScore = 12  },
                new Employee { EmployeeNumber = 4, Name = "D", Department = "D3", MonthlyScore = 15  },
                new Employee { EmployeeNumber = 5, Name = "E", Department = "D3", MonthlyScore = 17  },
                new Employee { EmployeeNumber = 6, Name = "F", Department = "D3", MonthlyScore = 122  },
                new Employee { EmployeeNumber = 7, Name = "G", Department = "D4", MonthlyScore = 17 },
                new Employee { EmployeeNumber = 8, Name = "H", Department = "D4", MonthlyScore = 199  },
                new Employee { EmployeeNumber = 9, Name = "I", Department = "D4", MonthlyScore = 100 },
            }
            .GroupBy(x => x.Department)
            .ToList()
            .ForEach(x => {
                Console.WriteLine(x.Key);
                foreach (Employee item in x.OrderBy(y => y.MonthlyScore).Take(2))
                {
                    Console.WriteLine(string.Format("{0}, {1}, {2}", item.EmployeeNumber, item.Department, item.MonthlyScore));
                }
            });
    /*
    Output:
    D1
    1, D1, 10
    D2
    3, D2, 12
    2, D2, 40
    D3
    4, D3, 15
    5, D3, 17
    D4
    7, D4, 17
    9, D4, 100
    */
