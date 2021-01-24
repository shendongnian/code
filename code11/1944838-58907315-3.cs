    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System;
    
    namespace ConsoleApp1
    {
       public  class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }
    
            public void SayHello()
            {
                Console.WriteLine("Hello, I am {0}",Name);
            }
            public static void Main()
            {
                Student stu = new Student() { Name="test1",Age=22};
                stu.SayHello();
                
            }
        }
    }
