    List<string> mylist = new List<string>();
	mylist.Add("this is my first addition to the list");
	for(int i = 0; i < mylist.Count; i++)
	{
		Console.WriteLine(mylist[i]);
	}
	Console.WriteLine("next enter will delete the first entry");
	Console.ReadLine();
	mylist.RemoveAt(0);
	for (int i = 0; i < mylist.Count; i++)
	{
		Console.WriteLine(mylist[i]);
	}
	Console.WriteLine("there should not have been any entry between this and the last time");
	Console.ReadLine();
