	{
		MyList.Add(new Dictionary<string,int>());
		MyList.Add(new Dictionary<string,int>());
		MyList[0].Add("Dictionary 1", 1);
		MyList[0].Add("Dictionary 1", 2);
		MyList[0].Add("Dictionary 2", 3);
		MyList[0].Add("Dictionary 2", 4);
		foreach (var dictionary in MyList)
			foreach (var keyValue in dictionary)
				Console.WriteLine(string.Format("{0} {1}", keyValue.Key, keyValue.Value));
	}
	
