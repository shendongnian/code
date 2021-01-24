    public class TestController : ControllerBase
    {
    	private readonly MyDbContext dbContext;
    	private readonly DbConnection dbConnection;
    
    	public TestController(MyDbContext dbContext,
    		DbConnection dbConnection)
    	{
    		this.dbContext = dbContext;
    		this.dbConnection = dbConnection;
    	}
    
    	public void Test2()
    	{
    		IExecutionStrategy strategy = dbContext.Database.CreateExecutionStrategy();
    		strategy.Execute(() =>
    		{
    			using (DbTransaction transaction = dbConnection.BeginTransaction())
    			{
    				Client client = new Client();
    				client.ClientId = 3;
    				client.Name = "New Client 3";
    
    				dbContext.Database.UseTransaction(transaction);
    
    				dbContext.Entry<Client>(client).State = EntityState.Modified;
    				    
    				List<Client> clients = new List<Client>();
    				clients.Add(new Client
    				{
    					ClientId = 1,
    					Name = "New Client 1",
    				});
    				clients.Add(new Client
    				{
    					ClientId = 2,
    					Name = "New Client 2",
    				});
    				clients.Add(new Client
    				{
    					ClientId = 4,
    					Name = "New Client 4",
    				});
    
    				string sql = "UPDATE Client SET Name = @Name WHERE ClientId = @ClientId;";
    
    				try
    				{
    					dbContext.SaveChanges();
    
    					dbConnection.Execute(sql, clients, transaction: transaction);
    
    					transaction.Commit();
    				}
    				catch (System.Exception ex)
    				{
    
    				}
    			}
    		});
    	}
    }
