	var bc = new BlockingCollection<string>();
	for ( int i = 0 ; i < 5 ; i++ )
	{
		new Thread( () =>
			{
				foreach ( var xml in bc.GetConsumingEnumerable() )
				{
					// do work
				}
			}
		).Start();
	}
	bc.Add( xml_1 );
	bc.Add( xml_2 );
	...
	bc.CompleteAdding(); // threads will end when queue is exhausted
