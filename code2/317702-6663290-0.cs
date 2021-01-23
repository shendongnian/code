    StreamReader sr = new StreamReader("TestFile.txt")
    try
    {
        string line;
        // Read and display lines from the file until the end of 
        // the file is reached.
        while ((line = sr.ReadLine()) != null) 
        {
            Console.WriteLine(line);
        }
    }
    finally
    {
        sr.Dispose();
    }
