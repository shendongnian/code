public class AccountBase
{
    [Key]
    public long AccountId { get; set; }
    public string AccountName { get; set; }
    public bool IsDeleted { get; set; }
    [NotMapped]
    public bool Found => AccountId > 0;
}
public class AccountDataModel : AccountBase
{
}
public class AccountCount : AccountBase
{
   public int RowCount { get; set; }
}
Then, in my dbContext:
public class AccountDbContext : DbContext
{
    private DbSet<AccountDataModel> TAccount { get; set; }
    private DbSet<AccountCount> AccountList { get; set; }
    public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
    {
    }
    public Account GetAccountById(long accountId)
    {
        var pAccount = new SqlParameter("accountId", accountId);
        Account account = TAccount.FromSql("EXEC dbo.SPR_Account_GetById @accountId", pAccount).FirstOrDefault();
        return account;
    }
    public List<Account> GetAccounts(int offset, int limit)
    {
        var pOffset = new SqlParameter("offset", offset);
        var pLimit = new SqlParameter("limit", limit);
        var dataSet = AccountList.FromSql($"EXEC dbo.SPR_Account_GetAll @offset=@offset,@limit=@limit", pOffset, pLimit).ToList();
        return dataSet;
    }
}
