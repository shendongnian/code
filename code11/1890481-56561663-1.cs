    using System;
    using System.Linq;
    static void Main(string[] args)
    {
        string dirty1 = "\"Name's\",     \"Sex\", \"Age\", \"Height_(in)\", \"Weight (lbs)\"";
        string dirty2 = "\" LatD\", \"LatM \", 'LatS', \"NS\", \"LonD\", \"LonM\", \"LonS\", \"EW\", \"City\", \"State\"";
        Console.WriteLine(Clean(dirty1));
        Console.WriteLine(Clean(dirty2));
    
        Console.ReadKey();
    }
    
    private static string Clean(string dirty)
    {
        return dirty.Split(',').Select(item => item.Trim(' ', '"', '\'')).Aggregate((a, b) => string.Join(", ", a, b));
    }
    private static string CleanNoLinQ(string dirty)
    {
        string[] items = dirty.Split(',');
        for(int i = 0; i < items.Length; i++)
        {
            items[i] = items[i].Trim(' ', '"', '\'');
        }
        return String.Join(", ", items);
    }
