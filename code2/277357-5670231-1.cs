    void Main()
    {
        string path = @"D:\tmp\so5670107.txt";
        string[] lines = File.ReadAllLines(path);
        string prefix = LongestCommonPrefix(lines);
        prefix.Dump();
    }
    
    static string LongestCommonPrefix(string a, string b)
    {
        int length = 0;
        for (int i = 0; i < a.Length && i < b.Length; i++)
        {
            if (a[i] == b[i])
                length++;
            else
                break;
        }
        return a.Substring(0, length);
    }
    
    static string LongestCommonPrefix(IEnumerable<string> strings)
    {
        return strings.Aggregate(LongestCommonPrefix);
    }
