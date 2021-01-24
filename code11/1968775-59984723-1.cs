csharp
public async Task<IList<ContactAndAccounts>> GetAll()
{
    var accounts = await _dbContext.Account.Where(x => x.Name == "Amazing").ToListAsync();
    
    var contacts = await GetContacts(accounts.Select(o => o.Id));
    // Map contacts to accounts in memory
    return accounts;
}
public async Task<IList<contact>> GetContacts(List<Guid> ids)
{
    return await _dbContext.Contact.Where(x => ids.Contain(x.AccountLinkId)).ToListAsync();
}
