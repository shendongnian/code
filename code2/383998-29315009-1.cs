    using System;
    using System.Collections.Generic;
    
    using System.Text;
    using System.IO;
    
    namespace_File_Handling
    {
    
        class Program
        {
            static void Main(string[] args)
             {
                 
                string path = @"E:\File.txt";
                StreamReader r1 = new StreamReader(path);
                string m = r1.ReadToEnd();
                Console.WriteLine(m);
                Console.ReadKey();
                r1.Close();
                StreamWriter wr = File.AppendText(path);
                string na = Convert.ToString(Console.ReadLine());
                 wr.WriteLine(na);
                wr.Close();
                Console.WriteLine(na);
                Console.ReadKey();
                
                StreamReader rd = new StreamReader(path);
                string val = rd.ReadToEnd();
                Console.WriteLine(val);
                
                rd.Close();
                Console.ReadKey();
               
    
            }
        }
    }
