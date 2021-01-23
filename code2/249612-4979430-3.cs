    static void Main()
    {
        // int[] i = new int[5];
        int[] i = ReadInNum(5);
        for (int a = 0; a < i.Length; a++)
        {
            Console.Write(i[a]);  // !
        }
    }
    static int[] ReadInNum(int size)
    {
          int[] readIn  = new int[size];
          for (int i = 0; i < readIn.Length; i++)
               ...
    }
