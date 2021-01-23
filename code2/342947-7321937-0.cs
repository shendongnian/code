	public static Encoding[] GetList()
	{
		ArrayList arrayList;
		arrayList = new ArrayList();
		for ( int i = 0; i < 65535; i++ )
		{
			try
			{
				arrayList.Add( Encoding.GetEncoding( i ) );
			}
			catch(Exception ex)
			{
			}
		}
		return (Encoding[])arrayList.ToArray( typeof( Encoding ) );
	}
