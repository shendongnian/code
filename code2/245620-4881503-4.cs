	void Main()
	{
		LinkedList<string> myList = new LinkedList<string>();
		myList.AddLast("aaa");
		myList.AddLast("aaa");
		myList.AddLast("bbb");
		myList.AddLast("bbb");
		myList.AddLast("aaa");
		myList.AddLast("aaa");
		myList.AddLast("aaa");
		IGrouping<int,string> ggg;
		
		var groups=myList.GroupConsecutive((a,b)=>a==b);
		
		ILookup<string,int> lookup=groups.ToLookup(g=>g.First(),g=>g.Count());
		
		foreach(var x in lookup["aaa"])
		{
			Console.WriteLine(x); //outputs 2 then 3
		}
		foreach(var x in lookup["bbb"])
		{
			Console.WriteLine(x); //outputs 2
		}
	
	}
	
	
