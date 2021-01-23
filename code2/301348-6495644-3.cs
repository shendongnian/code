    public IList<Customer> GetByExample(Customer customer, string[] propertiesToExclude){
        Example customerQuery = Example.Create(customer);
        Criteria nameCriteria = customerQuery.CreateCriteria<Name>();
        nameCriteria.Add(Example.create(customer.Name));
        propertiesToExclude.ForEach(x=> customerQuery.ExcludeProperty(x));
        propertiesToExclude.ForEach(x=> nameCriteria.ExcludeProperty(x));
        return customerQuery.list();
    }
