    static void Main(string[] args)
    {
        int sum = 0;
        String num = Console.ReadLine();
        char[] sep = num.ToCharArray();
        for (int i = 0; i < sep.Length; i++)
        {
            sum += int.Parse(sep[i].ToString());
        }
        Console.WriteLine(sum);
        Console.ReadLine();
    }
