    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] contents = File.ReadAllLines(@"f.txt");
                
                var sorted = contents.Select(line => new
                {// Make sure that you use the index depend on your line
                    SortKey = DateTime.Parse(line.Split(',')[2]),
                    
                    Line = line
                    
            }
                      ).OrderBy(x => x.SortKey).ToList();
    
    
                sorted.ForEach(Console.WriteLine);
              
                
    
            }
        }
    }
       
