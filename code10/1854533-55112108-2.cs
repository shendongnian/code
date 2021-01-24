	private const int MAX_RETRY = 10;
    private const int RETRY_INTERVAL_MS = 1000;
	private string lastProcessedPosition = null;
	public void Start(string connectionString, string sql)
	{
		var exceptions = new List<Exception>();
		for (var i = 0; i < MAX_RETRY; i++)
		{
			try
			{
				if (Process(connString, sql, lastProcessedPosition)) return;
			}
			catch(Exception ex)
			{
				exceptions.Add(ex);
			}
			System.Threading.Thread.Sleep(RETRY_INTERVAL_MS);
		}
		throw new AggregateException(exceptions);
	}
