    public static class SessionExtender
    {
    	public static void AddWithTimeout(this HttpSessionState session,
    		string name,
    		object value,
    		TimeSpan expireAfter)
    	{
    		lock (session)
    		{
    			session[name] = value;
    		}
    		
    		//add cleanup task that will run after "expire"
    		Task.Delay(expireAfter).ContinueWith((task) => {
    			lock (session)
    			{
    				session.Remove(name);
    			}
    		});
    	}
    }
