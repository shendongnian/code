C#
public MyDatabaseContext(string dataProvider, string connectionString)
{
    _dataProvider = dataProvider;
    _connectionString = connectionString;
    OpenConnection();
}
But let `OpenConnection()` not be public, as you don't want interlopers calling it redundantly:
    protected void OpenConnection()
    {
        // ...
    }
You're correctly calling the base constructor in EmployeeDatabaseContext's constructor, so that's fine. 
And here's how you use it in a using statement:
C#
public void test()
{
    using (var ctxt = new EmployeeDatabaseContext(someProviderString, someConnString))
    {
        //  Do stuff with ctxt
        //  ctxt.Dispose() will be called when control exits this block. 
    }
}
