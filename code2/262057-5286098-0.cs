    private static void Main(string[] args)
    {
        Console.WriteLine(linq(@"szuizu_4156424324_hjvlahsjlvhlkd_&&§"));
        Console.Read();
    }
    
    public static char[] linq(string text)
    {
        char[] result = text
                    .Where(Char.IsLetter)
                    .GroupBy(x => x)
                    .Where(g =>g.Count() > 1)
                    .Select(g => g.Key).ToArray();
    
        return result;
    }
