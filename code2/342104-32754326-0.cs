    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace TRIAL
    {
        public class Class1
        {
            static void Main(string[] args)
            {
               string[] fileArray = Directory.GetDirectories("YOUR PATH");
               for (int i = 0; i < fileArray.Length; i++)
               {
    
                   Console.WriteLine(fileArray[i]);
               }
                Console.ReadLine();
            }
        }
    }
