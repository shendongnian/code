    using (StreamReader sr = new StreamReader("TestFile.txt")) 
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            Console.WriteLine(line);
        }
    }
