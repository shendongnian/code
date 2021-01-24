        public class Program
    {
        static void Main(string[] args)
        {
            //WriteH();
            //WriteS();
            MoveLetters();
        }
        /*public static void MoveLetters()
        {
            int i = 0;
            while (i < 100)
            {
                WriteH(i);
                WriteS(i);
                i++;
                System.Threading.Thread.Sleep(20);
                Console.Clear();
            }
        }*/
        public static void MoveLetters()
        {
            int i = 0;
            while (true)
            {
                for(i=0; i<100; i++)
                {
                    WriteH(i);
                    WriteS(i);
                    System.Threading.Thread.Sleep(20);
                    Console.Clear();
                }
                for(i=100; i>0; i--)
                {
                    WriteH(i);
                    WriteS(i);
                    System.Threading.Thread.Sleep(20);
                    Console.Clear();
                }
            }
        }
        public static void WriteH(int xPosition)
        {                            
                for (var row = 0; row < 7; row++)
                {
                    for (var col = 0; col < 7; col++)
                    {
                        if ((col == 1 || col == 5) || (row == 3 && col > 1  && col < 6))
                        {
                            Console.SetCursorPosition(col + xPosition, row);
                            Console.Write("#");
                        }
                    }
                    Console.WriteLine();
                }             
        }
        public static void WriteS(int xPosition)
        {
            for (var row = 0; row < 7; row++)
            {
                for (var col = 0; col < 7; col++)
                {
                    if (((row == 0 || row == 3 || row == 6) && col > 1 && col < 5)
                        || (col == 1 && (row == 1 || row == 2 || row == 6))
                        || (col == 5 && (row == 0 || row == 4 || row == 5)))
                    {
                        Console.SetCursorPosition(col + 7 + xPosition, row);
                        Console.Write("#");
                    }
                }
                Console.WriteLine();
            }
        }
    }
