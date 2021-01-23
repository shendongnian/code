    static void Main(string[] args)
    {
        int i = 0;
        while (true)
        {
            getresponse(ref i);
        }
    }
    public static void getresponse(ref int i)
    {
       i++;
       System.Console.WriteLine(i);
    }
