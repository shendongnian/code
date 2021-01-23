    List<string> Getlist()
    {
        List<string> mylist= new List<string>();
		for (int i = 0; i < n; i++)
		{
			var CDF = GetCDF(); // IEnumerable
			if (!CDF.Any())
			{
                            Thread.Sleep(1000); //Sleep for 1 second.   
			    fail++;
			    return Getlist();
			}
			string item = GetNext(CDF);
			mylist.Add(item);
		}
        
        return mylist;
    }
