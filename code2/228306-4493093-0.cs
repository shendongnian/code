    List<String> MasterList = new List<string> { "A", "B", "C", "D", "E" };
    List<String> ListOne = new List<string> { "A", "B", "C" };
    List<String> ListTwo = new List<String> { "B", "D" };
    
    ListOne.SelectMany(i => 
	ListTwo.Where(i2 => i != i2)
		   .Select(i2 => 
				{
					if (MasterList.IndexOf(i) < MasterList.IndexOf(i2))
						return string.Format("{0}-{1}", i, i2);
					else
						return string.Format("{0}-{1}", i2, i);
				}
		   ));
