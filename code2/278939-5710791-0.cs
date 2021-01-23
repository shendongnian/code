	public static CopyFoos() 
	{
		var client = new AmazonS3Client(...);
		var foos = GetFoos().ToList();
		var asyncs = new List<IAsyncResult>();
		foreach(var foo in foos)
		{
		    var request = new CopyObjectRequest { ... };  
		    
			asyncs.Add(client.BeginCopyObject(request, EndCopy, client));
		}
		
		foreach(IAsyncResult ar in asyncs)
		{
			if (!ar.IsCompleted)
			{
				ar.AsyncWaitHandle.WaitOne();
			}
		}
	}
	
	private static EndCopy(IAsyncRequest ar) 
	{    
		((AmazonS3Client)ar.AsyncState).EndCopyObject(ar);
	}
	
