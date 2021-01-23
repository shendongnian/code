    public IEnumerable<Splitting> Get(Guid companyId, long customerId)
    {
        CustomerRepository customersRep = new CustomerRepository();
        var customers = customersRep.Get(companyId);
        return GetQuery().Join(customers,
             s => s.CustomerId,
             c => c.Id,
             (s, c) => new { s, c }).
             Where(sc => sc.c.Id == customerId).
             Select(sc => sc.s).
             ToList();
    }
