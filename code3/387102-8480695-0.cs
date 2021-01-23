    public class BackgroundSmtpService
    {
    	private ILog _log = LogManager.GetLogger(typeof(BackgroundSmtpService));
    	private readonly SmtpService SmtpService;
    	private static Thread _watchThread;
    	private static List<Email> _emailToSend = new List<Email>();
    
    	public BackgroundSmtpService(SmtpService smtpService)
    	{
    		SmtpService = smtpService;
    	}
    
    	public void Send(Email email)
    	{
    		lock (_emailToSend)
    		{
    			_emailToSend.Add(email);
    		}
    		EnsureRunning();
    	}
    
    	private void EnsureRunning()
    	{
    		if (_watchThread == null || !_watchThread.IsAlive)
    		{
    			lock (SmtpService)
    			{
    				if (_watchThread == null || !_watchThread.IsAlive)
    				{
    					_watchThread = new Thread(ThreadStart);
    					_watchThread.Start();
    				}
    			}
    		}
    	}
    
    	private void ThreadStart()
    	{
    		try
    		{
    			while (true)
    			{
    				Thread.Sleep(30000);
    				try
    				{
    					lock (_emailToSend)
    					{
    						var emails = _emailToSend;
    						_emailToSend = new List<Email>();
    						emails.AsParallel().ForAll(a=>SmtpService.Send(a));
    					}
    				}
    				catch (Exception e)
    				{
    					_log.Error("Error during running send emails", e);
    				}
    			}
    		}
    		catch (Exception e)
    		{
    			_log.Error("Error during running send emails, outer", e);
    		}
    	}
    }
