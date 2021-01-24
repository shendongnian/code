	static void TestSelect(HtmlDocument htmlDoc, string xpath)
	{
		Console.WriteLine("\nInput path: " + xpath);
		var splitPath = xpath.Split('/');
		for (int i = 2; i <= splitPath.Length; i++)
		{
			if (splitPath[i-1] == "")
				continue;
			var thisPath = string.Join("/", splitPath, 0, i);
			Console.Write("Testing \"{0}\": ", thisPath);
			var result = htmlDoc.DocumentNode.SelectNodes(thisPath);
			Console.WriteLine("result count = {0}", result == null ? "null" : result.Count.ToString());
		}
	}
