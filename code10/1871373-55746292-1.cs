     [OperationContract]
    public IEnumerable<Employee> GetEmployees()
            {
                List<Employee> list = new List<Employee>();
                NorthwindContext db = new NorthwindContext();
                list = db.Employees.ToList();
                return list;
            }
