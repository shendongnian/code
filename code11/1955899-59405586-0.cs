public class TestController : ControllerBase
{
    private readonly MyDbContext _dbContext;
    private readonly IDbConnection _dbConnection;
    public TestController(MyDbContext dbContext,
        IDbConnection dbConnection)
    {
        _dbContext = dbContext;
        _dbConnection = dbConnection;
    }
    public void Test2()
    {
		varclient = new Client();
		client.ClientId = 3;
		client.Name = "New Client 3";
	
		//is the correct way to attach and entrity mark as modified.
		 _dbContext.Entry<Client>(client).State = EntityState.Modified;
		 _dbContext.SaveChanges();
	
		var clients = new List<Client>();
		clients.Add(new Client { ClientId = 1, Name = "New Client 1", });
		clients.Add(new Client { ClientId = 2, Name = "New Client 2", });
		clients.Add(new Client { ClientId = 4, Name = "New Client 4", });
        using (IDbTransaction transaction = _dbConnection.BeginTransaction())
        {
            string sql = "UPDATE Client SET Name = @Name WHERE ClientId = @ClientId;";
			//is this the correct way to call dapper
            _dbConnection.Execute(sql, clients, transaction: transaction);
            transaction.Commit();
        }
    }
}
