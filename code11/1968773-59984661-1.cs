    public async Task<IList<ContactAndAccounts>> GetAll()
    {
        var accounts = await _dbContext.Account.Where(x => x.Name == "Amazing").ToListAsync();
    
        await Task.WhenAll(accounts.Select(async account => 
        {
            accounts.Contact = await GetContact(account.Id);
        }));
    
        return accounts;
    }
