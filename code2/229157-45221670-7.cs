    using System;
    
    namespace AsciiBorder
    {
        class Program
        {
            static void Main(string[] args)
            {
                int topleft = 218;
                int hline = 196;
                int topright = 191;
                int vline = 179;
                int bottomleft = 192;
                int bottomright = 217;
    
                Console.OutputEncoding = System.Text.Encoding.GetEncoding(28591);
                //draw top left corner
                Write(topleft);
                //draw top horizontal line
                for (int i = 0; i < 10; i++)
                    Write(hline);
                //draw top right corner
                Write(topright);
                Console.WriteLine();
                //draw left and right vertical lines
                for (int i = 0; i < 6; i++)
                {
                    Write(vline);
                    for (int k = 0; k < 10; k++) {
                        Console.Write(" ");
                    }
                    WriteLine(vline);
                }
                //draw bottom left coner
                Write(bottomleft);
                //draw bottom horizontal line
                for (int i = 0; i < 10; i++)
                    Write(hline);
                //draw bottom right coner
                Write(bottomright);
                Console.ReadKey();
            }
            static void Write(int charcode)
            {
                Console.Write((char)charcode);
            }
            static void WriteLine(int charcode)
            {
                Console.WriteLine((char)charcode);
            }
        }
    }
