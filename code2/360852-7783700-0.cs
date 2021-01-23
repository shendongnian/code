	readonly ConcurrentDictionary<string, ConcurrentDictionary<int, int>> dict = new ConcurrentDictionary<string, ConcurrentDictionary<int, int>>();
	void AddUpdateItem( string s, int k, int v )
	{
		ConcurrentDictionary<int, int> subDict;
		while ( true )
		{
			if ( dict.TryGetValue( s, out subDict ) )
			{
				subDict[ k ] = v;
				break;
			}
            // speculatively create new sub-dictionary
			subDict = new ConcurrentDictionary<int, int>();
			subDict[ k ] = v;
            // this can only succeed for one thread
			if ( dict.TryAdd( s, subDict ) ) break;
		}
	}
