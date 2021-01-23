	string source  = Console.ReadLine();
	string destination = Console.ReadLine();
	int numberOfFilesToCopy = int.Parse(Console.ReadLine());
	
    DirectoryInfo di = new DirectoryInfo(source);
	var files = di.GetFiles();
	for(i=0;i < math.Max(files.Length, numberOfFilesToCopy);i++)
	{
		files[i].CopyTo(destination);
	}
	
