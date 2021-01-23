    static int[] ReadInNum(int count)
    {
        int[] values = new int[count];
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine("Please enter an interger");
            values[i] = int.Parse(Console.ReadLine());
        }
        return values;
    }
