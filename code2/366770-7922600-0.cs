    static bool matchesPermutation(string test, string search)
    {
        string remaining = search;
        for (int i = 0; i < test.Length; i++)
        {
            int pos = remaining.IndexOf(test[i]);
            if (pos == -1)
                return false;
            else
                remaining = remaining.Remove(pos, 1);
        }
        return true;
    }
    
    static int findPermutation(string test, string search)
    {
        for (int i = 0; i < test.Length-search.Length+1; i++)
            if (matchesPermutation(test.Substring(i, search.Length), search))
                return i;
        return -1;
    }
    static void Main(string[] args)
    {
        string test = "INEEDTOGETAHAIRCUT";
        string search = "AHRI";
        int foundPos = findPermutation(test, search);
        Console.WriteLine(foundPos);
        if (foundPos != -1)
            Console.WriteLine(test.Substring(foundPos, search.Length));
    }
