     using System;
     using System.IO;
     
     static void Print(string path, int? rec, int? tree, bool color, int? level = 0)
            {
                if ((rec != null && level > rec) || path == null) return; //stop
                if (rec == null) rec = 0;
    
                string[] dir;
                string[] fil;
    
                try
                {
                    dir = Directory.GetDirectories(path);
                    fil = Directory.GetFiles(path);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
    
                foreach (string s in dir) //vypis directory
                {
                    WriteSpace(level,tree);
                    Console.WriteLine(s);
                    Print(s, rec, tree, color, level + 1); // rekurzia
                }
    
                if (color) //parameter /c
                {
                    ConsoleColor def = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    foreach (string s in fil) // vypis file
                    {
                        WriteSpace(level, tree);
                        Console.WriteLine(s);
                    }
                    Console.ForegroundColor = def;
                }
                else
                {
                    foreach (string s in fil)
                    {
                        WriteSpace(level, tree);
                        Console.WriteLine(s);
                    }
                }
            }
    
            private static void WriteSpace(int? level, int? tree)
            {
                for (int i = 0; i < level*tree; i++)
                    Console.Write(" ");
            }
    }
