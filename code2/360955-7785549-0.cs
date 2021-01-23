    public static List<Customer> Find(Criteria criteria)
    {
        List<Customer> customers = Repository.GetCustomers();
        var customers2 = customers.Where(x => criteria.Departments.Contains(x.Department.ToString()));
        var customers3 = customers2.Where(x => x.Surname == criteria.Surname);
        return customers3.ToList();
    }
