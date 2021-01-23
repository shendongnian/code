    class Program
    {
        static void Main()
        {
            int[] i = new int[5];
            ReadInNum(i);
            for (int a = 0; a < 5; a++)
            {
                Console.Write(a);
            }
        }
        static int[] ReadInNum(int[] readIn)
        {
            for (int i = 0; i < readIn.Length; i++)
            {
                Console.WriteLine("Please enter an interger");
                readInn[i] = Console.Read();
            }
            
            return readIn;
        }
    }
