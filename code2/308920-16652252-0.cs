	public static String CompactWhitespaces( String s )
	{
		StringBuilder sb = new StringBuilder( s );
		CompactWhitespaces( sb );
		return sb.ToString();
	}
	public static void CompactWhitespaces( StringBuilder sb )
	{
		if( sb.Length == 0 )
			return;
		// set [start] to first not-whitespace char or to sb.Length
		int start = 0;
		while( start < sb.Length )
		{
			if( Char.IsWhiteSpace( sb[ start ] ) )
				start++;
			else 
				break;
		}
		// if [sb] has only whitespaces, then return empty string
		if( start == sb.Length )
		{
			sb.Length = 0;
			return;
		}
		// set [end] to last not-whitespace char
		int end = sb.Length - 1;
		while( end >= 0 )
		{
			if( Char.IsWhiteSpace( sb[ end ] ) )
				end--;
			else 
				break;
		}
		// compact string
		int dest = 0;
		bool previousIsWhitespace = false;
		for( int i = start; i <= end; i++ )
		{
			if( Char.IsWhiteSpace( sb[ i ] ) )
			{
				if( !previousIsWhitespace )
				{
					previousIsWhitespace = true;
					sb[ dest ] = ' ';
					dest++;
				}
			}
			else
			{
				previousIsWhitespace = false;
				sb[ dest ] = sb[ i ];
				dest++;
			}
		}
		sb.Length = dest;
	}
