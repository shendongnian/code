    static void Show(double average)
    {
        Console.WriteLine("The values are:");
        for (int i = 0; i < score.Length; i++)
        {
            Console.WriteLine(string.Format("The {0} value you entered was {1}", i + 1, score[i]));
        }
        Console.WriteLine("The average is: {0}", average);
    }
