    static void Main(string[] args)
    {
       List<string> listStrings = new List<string>(){ "C#", "Asp.Net", "SQL Server", "PHP", "Angular"};
       string CommaSeparateString = GenerateCommaSeparateStringFromList(listStrings);
       Console.Write(CommaSeparateString);
       Console.ReadKey();
    }
    private static string GenerateCommaSeparateStringFromList(List<string> listStrings)
    {
       return String.Join(",", listStrings);  
    }
