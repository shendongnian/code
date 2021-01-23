    public static void StartGenerationOfNames()
    {
        string[] lines = System.IO.File.ReadAllLines("names.txt");
    
        foreach (string line in lines)
        {
            Debug.WriteLine(line);
        }
    }
