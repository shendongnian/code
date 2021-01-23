    void Main()
    {
       using(new SetupTransaction())
       {
       	//Your test
       }
    }
    
    public class SetupTransaction : IDisposable
    {
    	private TransactionScope transaction;
    	
    	public SetupTransaction()
    	{
    		transaction = new TransactionScope();
    		//Do your stuff here
    	}
    	
    	public void Dispose()
    	{
    		transaction.Dispose();
    	}
    }
