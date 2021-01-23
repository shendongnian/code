    static void Main(string[] args)
    {
        Console.WriteLine("enter s1 :");
        string s1 = Console.ReadLine();
        Console.WriteLine("enter s2 :");
        string s2 = Console.ReadLine();
        Console.WriteLine("note: zero means there is *no* first dif index starting from s1 ");    
        Console.WriteLine("first dif index of s1 :{0}", findFirstDifIndex(s1, s2)+1);
    }
    
    private static int findFirstDifIndex(string s1, string s2)
    {
        for (int i = 0; i <Math.Min(s1.Length, s2.Length); i++)
            if (s1[i] != s2[i]) 
                return i;
    
        return -1;
    }
