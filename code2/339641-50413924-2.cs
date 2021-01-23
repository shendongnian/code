    string path = ""; // Again, path.
    string[] lines = File.ReadAllLines(path);
    foreach(string line in lines)
    {
        try
        {
            Console.WriteLine(line);
        } catch(Exception ex, IOException ioex)
        { /* exception */ }
    }
