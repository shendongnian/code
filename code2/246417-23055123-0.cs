    Seem like this is what you are looking at:
	class Bila
		{
			public string Name;
			public List<string> Adresses;
		}
		 var justNumbers = Enumerable.Range(0, 10);
	Func<int,List<string>> foo = delegate(int j)
		{
			List<string> lst = new List<string>();
			for (int kk = 0; kk < j; kk++)
			{
				lst.Add("String_" + kk.ToString());
			}
			return lst;
		};
	var zilla3 = (from x in justNumbers
				  select new Bila
				  {
					  Name = "Name_" + x.ToString(),
					  Adresses = foo(x),
				  }).ToArray();
