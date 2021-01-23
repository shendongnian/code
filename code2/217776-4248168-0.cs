static void Run()
{
	var list = new string[] {"A", "A.B.D", "A",
							"A.B", "E", "F.E",
							"F", "B.C",
							"Q.X", "Q.Y",
							"D.A.A", "D.A.B"
						};
	int size = 0;
	var prefixList = new string[list.Length];
	Array.Copy(list, prefixList, list.Length);
	do
	{
		size = prefixList.Length;
		for (int i = 0; i &lt; list.Length; i++)
			prefixList 
				= prefixList
				.Where(c =&gt; !c.StartsWith(list[i]) || c == list[i])
				.Distinct()
				.ToArray();
	} while (size != prefixList.Length);
	foreach (string s in prefixList)
		Console.WriteLine(s);
	Console.ReadLine();
}
