      using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace oops3
    {
        interface I5
        {
            void getdata();
    
        }
        interface I6
        {
            void getdata();
    
        }
    
        class MyClass:I5,I6
        {
            void I5.getdata()
            {
               Console.WriteLine("I5 getdata called");
            }
            void I6.getdata()
            {
                Console.WriteLine("I6 getdata called");
            }
            static void Main(string[] args)
            {
                MyClass obj = new MyClass();
                ((I5)obj).getdata();
                     
    
                Console.ReadLine();
    
            }
    
           
        }
    }
