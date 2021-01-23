	string contents = File.ReadAllText("C:\\Work\\labtoolssnapshot.txt");
	string contents2 = File.ReadAllText("C:\\Work\\analyzercommonsnapshot.txt");
	string contents3 = File.ReadAllText("C:\\Work\\mobilesnapshot.txt");
	string outFile = "C:\\Work\\checksnapshot.properties";
	//1	
	if (contents.Contains(args[0]))
	{
		File.WriteAllText(outFile,"SASE=1");
	}
	else
	{
		File.WriteAllText(outFile,"SASE=0");
	}
	//2	
	if (contents2.Contains(args[0]))
	{
		File.AppendAllText(outFile,"Analyzer= 1");
	}
	else
	{
		File.AppendAllText(outFile,"Analyzer= 0");
	}
	//3
	if (contents3.Contains(args[0]))
	{
		File.AppendAllText(outFile,"mobile= 1");
	}
	else
	{
		File.AppendAllText(outFile,"mobile= 0");
	}
