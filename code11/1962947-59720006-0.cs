	static IEnumerable<string> generateCombinations( string[,] data )
	{
		int rows = data.GetLength( 0 );
		int cols = data.GetLength( 1 );
		if( rows <= 0 || cols <= 0 )
			yield break;
		// Reshape data into array of arrays, 1 array per column, skipping nulls at the same time.
		// It's faster to skip nulls in advance, before running the main loop.
		string[][] columns = new string[ cols ][];
		for( int c = 0; c < cols; c++ )
		{
			string[] column = Enumerable.Range( 0, rows )
				.Select( r => data[ r, c ] )
				.Where( str => null != str )
				.ToArray();
			// Ensure the column has at least a single non-null value, return otherwise.
			if( column.Length <= 0 )
				yield break;
			columns[ c ] = column;
		}
		// Iterator state, i.e. row indices. C# initializes arrays with zeros.
		int[] indices = new int[ cols ];
		// Another optimization here: reusing string builder across iterations.
		StringBuilder sb = new StringBuilder();
		// Run the main loop.
		while( true )
		{
			// Generate value at the current iterator state
			sb.Clear();
			for( int c = 0; c < cols; c++ )
			{
				if( c > 0 )
					sb.Append( '`' );
				sb.Append( columns[ c ][ indices[ c ] ] );
			}
			yield return sb.ToString();
			// Advance to the next value
			for( int c = cols - 1; true; c-- )
			{
				int i = indices[ c ];
				i++;
				if( i < columns[ c ].Length )
				{
					// Still have one more value in that column
					indices[ c ] = i;
					break;
				}
				// No more values in that column.
				if( c > 0 )
				{
					// Reset current index to 0, and continue left to the next column
					indices[ c ] = 0;
					continue;
				}
				// Finished - exit the function
				yield break;
			}
		}
	}
	static void Main( string[] args )
	{
		string[,] data = new string[ 3, 3 ]
		{
			{ "a", "c", "x" },
			{ "b", "d", "y" },
			{ null, null, "z" },
		};
		foreach( string c in generateCombinations( data ) )
			Console.WriteLine( c );
	}
