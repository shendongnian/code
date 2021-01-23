    static void ReadInNum(int[] readIn)
    {
        for (int i = 0; i < readIn.Length; i++)
        {
            Console.WriteLine("Please enter an interger");
            readIn[i] = int.Parse(Console.ReadLine());
        }
    }
