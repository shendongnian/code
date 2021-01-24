    public class MyDbContext : DbContext
    {
        static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1,1);
    	static readonly object lockObject = new object();
    
        public override int SaveChanges()
        {
            lock (lockObject)
                return base.SaveChanges();
        }
    
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await semaphoreSlim.WaitAsync();
    		try
    		{
                return await base.SaveChangesAsync();
    		}
    		finally
    		{
    			//When the task is ready, release the semaphore. It is vital to ALWAYS release the semaphore when we are ready, or else we will end up with a Semaphore that is forever locked.
    			//This is why it is important to do the Release within a try...finally clause; program execution may crash or take a different path, this way you are guaranteed execution
    			semaphoreSlim.Release();
    		}
        }       
    }
