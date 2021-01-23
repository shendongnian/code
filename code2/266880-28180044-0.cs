	File.WriteAllText("test.txt", "1234" + System.Environment.NewLine + "56789");
	
	long position = -1;
	long bytesRead = 0;
	int newLineBytes = System.Environment.NewLine.Length;
	
	using (var sr = new StreamReader("test.txt"))
	{
		string line = sr.ReadLine();
		bytesRead += line.Length + newLineBytes;
		
		Console.WriteLine(line);
	
		position = bytesRead;
	}
	
	Console.WriteLine("Wait");
	
	using (var sr = new StreamReader("test.txt"))
	{
		sr.BaseStream.Seek(position, SeekOrigin.Begin);
		Console.WriteLine(sr.ReadToEnd());
	}
