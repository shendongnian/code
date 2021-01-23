    class Program
    {
    static void Main()
    {
	CountLinesInFile("test.txt"); // sample input in file format
    }
    static long CountLinesInFile(string f)
    {
	long count = 0;
	using (StreamReader r = new StreamReader(f))
	{
	    string line;
	    while ((line = r.ReadLine()) != null)
	    {
		count++;
	    }
	}
	return count;
    }
    }
