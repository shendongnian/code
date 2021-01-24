public AppDbContext context { get; }
public RepositoryBankAccount(AppDbContext appDbContext)//<==Inject the AppDbContext
{
    context = appDbContext;//<==Do NOT create new instance here; assign the injected instance.
}
Then, in your `UnitOfWork` class, change the property `BankAccounts` as below:
private RepositoryBankAccount _BankAccounts;
public RepositoryBankAccount BankAccounts
{
    get
    {
        if (_BankAccounts == null)
        {
            _BankAccounts = new RepositoryBankAccount(db);//<==Note that `db` means `AppDbContext` is injected
        }
        return _BankAccounts;
    }
}
#By the way, avoid all these unnecessary wrappers over wrappers.
