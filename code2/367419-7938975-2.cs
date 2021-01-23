	...
	else
	{
		Messages.Add( path );
		Directories.Add( path );
		try
		{
			var dirs = Directory.GetDirectories( path );
			var tasks = dirs.Select(
				d => Task.Factory.StartNew(
					() => Travel( d, nesting - 1, null )
				)
			).ToArray();
			Task.WaitAll( tasks );
			foreach ( var t in tasks ) t.Dispose();
		}
		catch ( Exception x )
		{
			...
		}
	}
