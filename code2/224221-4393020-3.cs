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
		
		/// <summary>Each fetcher locks on itself and is initilized with null contents.
		/// The first thread to call fetcher.Contents will cause the fetch to occur, and
		/// block until completion.</summary>
		private class InternalFetcher
		{
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
						lock( this ) // "this" is an instance of InternalFetcher...
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
