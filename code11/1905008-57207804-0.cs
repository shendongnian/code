    public static void Main(string[] args)
    {
        char[] Alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        char[] rout1 = "JGDQOXUSCAMIFRVTPNEWKBLZYH".ToCharArray();
        char l1;
        Console.Write("Enter a character -- ");
        Char Letter = Convert.ToChar(Console.ReadLine());
        Console.WriteLine(Letter);
        int i;
        for (i = 0; i < 26; i++)
        {
            if (Letter == Alpha[i])
            {
                l1 = rout1[i];
                Console.WriteLine(l1);
                Console.ReadLine();
            }
        }
    }
