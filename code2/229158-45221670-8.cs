    using System;
    
    namespace AsciiBorder
    {
        class Program
        {
            const int topleft = 218, hline = 196, topright = 191, vline = 179, bottomleft = 192, bottomright = 217, cross = 197, topT = 194, bottomT = 193, leftT = 195, rightT = 180;
            const int space = 10/*this determine size of the single cell*/, spacer_ex = (space / 2) + 1;
            static void Main(string[] args)
            {            
                Console.OutputEncoding = System.Text.Encoding.GetEncoding(28591);
                Console.Title = "3x3 Board";
                DrawTop();
                DrawMidSpacer();
                DrawMiddle();
                DrawMidSpacer();
                DrawMiddle();
                DrawMidSpacer();
                DrawBottom();
    
                Console.ReadKey();
            }
            static void DrawBottom() {
                #region bottom
                Write(bottomleft);
                for (int i = 0; i < space; i++)
                    Write(hline);
                Write(bottomT);
                for (int i = 0; i < space; i++)
                    Write(hline);
                Write(bottomT);
                for (int i = 0; i < space; i++)
                    Write(hline);
                Write(bottomright);
    
                Console.WriteLine();
                #endregion
            }
            static void DrawMiddle() {
                #region middle
                Write(leftT);
                for (int i = 0; i < space; i++)
                    Write(hline);
                Write(cross);
                for (int i = 0; i < space; i++)
                    Write(hline);
                Write(cross);
                for (int i = 0; i < space; i++)
                    Write(hline);
                Write(rightT);
    
                Console.WriteLine();
                #endregion
            }
            static void DrawMidSpacer() {
                #region middlespacer
                for (int x = 0; x < spacer_ex; x++)
                {
                    Write(vline);
                    for (int i = 0; i < space; i++)
                        Console.Write(" ");
                    Write(vline);
                    for (int i = 0; i < space; i++)
                        Console.Write(" ");
                    Write(vline);
                    for (int i = 0; i < space; i++)
                        Console.Write(" ");
                    Write(vline);
    
                    Console.WriteLine();
                }
                #endregion
            }
            static void DrawTop() {
                #region top
                Write(topleft);
                for (int i = 0; i < space; i++)
                    Write(hline);
                Write(topT);
                for (int i = 0; i < space; i++)
                    Write(hline);
                Write(topT);
                for (int i = 0; i < space; i++)
                    Write(hline);
                Write(topright);
    
                Console.WriteLine();
                #endregion
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
