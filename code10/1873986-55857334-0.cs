	string nextVersion(string user_input)
	{
		var entries = user_input.Split('.')
								.Select( s => int.Parse(s) )
								.ToArray();
		
		void Inc(int index)
		{
			if ( index == 0 || ( entries[index] < 9 ) )
			{
				entries[index]++;
			}
			else
			{
				entries[index] = 0;
				Inc( index-1 );
			}
		}
		
		Inc( entries.Length-1 );
		
		return String.Join( ".", entries );
	}
