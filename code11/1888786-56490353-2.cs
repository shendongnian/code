    public async Task<List<string>> GetCustomerFirstLetter()
    {
        using (var dbContext = new MyDbContext())
        {
            return await dbContext.Set<Customer>().Select(x => x.lastName.Substring(0, 1)).Distinct().ToList();
        }
    }
