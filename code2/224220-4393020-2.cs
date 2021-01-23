	public class UrlFetcher
	{
		static Hashtable cache = Hashtable.Synchronized(new Hashtable());
		public static String GetCachedUrl(String url)
		{
			// exactly 1 fetcher is created per URL
			InternalFetcher fetcher = (InternalFetcher)cache[url];
			if( fetcher == null )
			{
				lock( cache.SyncRoot )
				{
					fetcher = (InternalFetcher)cache[url];
					if( fetcher == null )
					{
						fetcher = new InternalFetcher(url);
						cache[url] = fetcher;
					}
				}
			}
			// blocks all threads requesting the same URL
			return fetcher.Contents;
		}
		
		/// Each fetcher has its own lock and is initilized with null contents.
		/// The first thread to call fetcher.Contents will cause the fetch to 
		/// occur, and block until completion.
		private class InternalFetcher
		{
			static readonly Object theLock = new Object();
			private String url;
			private String contents;
			
			public InternalFetcher(String url)
			{
				this.url = url;
				this.contents = null;
			}
			
			public String Contents
			{
				get
				{
					if( contents == null )
					{
						lock( theLock )
						{
							if( contents == null )
							{
								contents = FetchFromWeb(url);
							}
						}
					}
					return contents;
				}
			}
		}
	}
