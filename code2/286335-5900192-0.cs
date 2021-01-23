    static void Main(string[] args) {
    
        var input = new[] {
            "\"formatter\": \"John\"", 
            "\"formatter\": \"Sue\"", 
            "\"formatter\": \"Greg\""
        };
    
        foreach (var s in input) {
            System.Console.Write("Original: [{0}]{1}", s, Environment.NewLine);
            System.Console.Write("Replaced: [{0}]{1}", ReFormat(s), Environment.NewLine);
            System.Console.WriteLine();
        }
                
        System.Console.ReadKey();
    }
    
    private static String ReFormat(String str) {
        //Use named capturing groups to make life easier
        var pattern = "(?<label>\"formatter\"): ([\"])(?<tag>.*)([\"])";
    
        //Create a substitution pattern for the Replace method
        var replacePattern = "${label}: ${tag}";
    
        return Regex.Replace(str, pattern, replacePattern, RegexOptions.IgnoreCase);
    }
