    static void Main(string[] args)
    {
        Console.WriteLine("Enter String:");
        string inputString = Console.ReadLine();
        Console.WriteLine();
        List<string> lstAnagrams = new List<string>();
        int numAnagram = 1;
                
        permute(inputString.ToCharArray(), 0, inputString.Length - 1, lstAnagrams);
        foreach(string anagram in lstAnagrams)
        {
            Console.WriteLine(numAnagram.ToString() + " " + anagram);
            numAnagram++;
        }
    
        Console.ReadKey();
    }
    
    static void permute(char[] word, int start, int end, List<string> lstAnagrams)
    {
        if (start == end)
            lstAnagrams.Add(string.Join("", word));
        else
        {
            for (int position = start; position <= end; position++)
            {
                swap(ref word[start], ref word[position]);
                permute(word, start + 1, end,lstAnagrams);
                swap(ref word[start], ref word[position]);
            }
        }
    }
    
    static void swap(ref char a, ref char b)
    {
        char tmp;
        tmp = a;
        a = b;
        b = tmp;
    }
