       private List<Employee> GetEmployeeDetails()
       {
            List<Employee> myEmployees = new List<Employee>();
            
            Employee Steve = new Employee()
                {
                    Address = new List<Address>() { new Address { City = "op", Street = "thatstreet", Zip = 23312 } },
                    Age = 23,
                    EmpId = "Emp1",
                    Name = "SteveIsTheName"
                };
            Employee Carol = new Employee()
                {
                    Address = new List<Address>() {
                        new Address { City = "op2", Street = "thatstreet2", Zip = 23313 },
                        new Address { City = "op3", Street = "thatstreet3", Zip = 23314 }},
                    Age = 24,
                    EmpId = "Emp2",
                    Name = "CarolIsTheName"
                };
            myEmployees.Add(Steve);
            myEmployees.Add(Carol);
            return myEmployees;
        }
