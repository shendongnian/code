    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Controls;
    
    namespace Readand_display
    {
        class Program
        {
            static void Main(string[] args)
            {
                Example2();
                Example1();
            }
    
            private static void Example2()
            {
                string TextBox1 = null;
                string TextBox2 = null;
                string TextBox3 = null;
    
                string[] lines = System.IO.File.ReadAllLines("file.cfg");
                char[] delimiter = { '=', '"' };
    
                if (lines.Count()>0)
                {
                     TextBox1 = lines[0].Split(delimiter)[2];
                     TextBox2 = lines[1].Split(delimiter)[2];
                     TextBox3 = lines[2].Split(delimiter)[2];
                }
                Console.WriteLine("TextBox1 = {0}, TextBox2 = {1}, TextBox3 = {2}", TextBox1, TextBox2, TextBox3); // show all the values in the line separated by comma
                Console.ReadKey();
    
            }
    
            private static void Example1()
            {
                string[] lines = System.IO.File.ReadAllLines("file.cfg");
                char[] delimiter = { '=', '"' };
    
                List<string> values = new List<string>();    // To store the values 1,2,3 
                foreach (var item in lines)
                {
                    List<string> line = item.Split(delimiter).ToList();
                    Console.WriteLine("{0}, {1}, {2}", line[0], line[1], line[2]); // show all the values in the line separated by comma
                    values.Add(line[2]);
                }
    
                foreach (var item in values)  // this is just to show your the values.
                {
                    Console.WriteLine(item);    // show just the 1,2,3 values
                }
            
                /*****************************
                 *  HERE YOU WOULD ASSIGN THE VALUES TO WHAT EVER OBJECT TYOU LIKE.
                 *  FOR EXAMPLE
                 *  "textbox1.text = values[0];
                 *  "textbox2.text = values[1];
                 *  "textbox3.text = values[2];
                 *  ******************************/
                Console.ReadKey();
            }
        }
    }
