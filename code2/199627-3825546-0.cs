    static void Main(string[] args)
    {
        string input = "asdfa/sada";
        string output = CleanFileName1(input);
        Console.WriteLine(output); // this prints: asdfasada
        Console.Read();
    }
    public static string CleanFileName1(string filename)
    {
        string file = filename;
        file = string.Concat(file.Split(System.IO.Path.GetInvalidFileNameChars(), 
                                        StringSplitOptions.RemoveEmptyEntries));
        if (file.Length > 250)
            file = file.Substring(0, 250);
        return file;
    }
