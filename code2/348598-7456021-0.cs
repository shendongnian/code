    public IEnumerable<Customer> Find(string filter)
    {
        //filter would be something like "Age >= 20"
        return internalCustomerList.Where(filter);
    }
