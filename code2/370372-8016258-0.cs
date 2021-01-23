    static void Main(string[] args)  
    {  
        List<string> range = WildcardFiles();
        foreach (string item in range)
        {
            // Do something with item
        }
    }  
    static List<string> WildcardFiles()
    {  
        List<string> listRange = new List<string>();  
        listRange.Add("q");  
        listRange.Add("s");  
        return listRange;  
    }  
