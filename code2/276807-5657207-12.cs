    public static class UnitOfWorkExtensions
    { 
    	public static void Execute(this IUnitOfWork unitOfWork, Action action)
    	{
    		try
    		{
    			unitOfWork.Start();
    			action.Invoke();
    			unitOfWork.Commit();
    		}
    		catch
    		{
    			unitOfWork.Rollback();
    			throw;
    		}
    	}
    }
