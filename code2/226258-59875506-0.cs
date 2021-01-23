    //by using this you can access the value of enum.
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace @enum
    {
        class temp
        {
           public enum names
            {
                mohitt,
                keval,
               Harshal,
               nikk
            }
    
        }
        class Program
        {
           
            static void Main(string[] args)
            {
              
                Console.WriteLine(temp.names.nikk);
                Console.ReadKey();
    
            }
        }
    }
