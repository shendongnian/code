    var enumerator = groups.GetEnumerator();				
	while (enumerator.MoveNext())
	{
		try
		{
			var e = enumerator.Current;
			listView1.Items.Add(e.Name);
		}
		catch (NoMatchingPrincipalException)
		{
		}
	}
