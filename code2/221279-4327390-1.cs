    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication12
    {
        class Program
        {
            static void Main(string[] args)
            {
                MyList<int> list1 = new MyList<int>();
                MyList<int> list2 = new MyList<int>();
                MyList<double> list3 = new MyList<double>();
                Console.WriteLine(list1.GetCount());
                Console.WriteLine(list2.GetCount());
                Console.WriteLine(list3.GetCount());
            }
        }
        
        public class MyList<T>
        {
            private static int _count;
            private int _myCount;
    
            public MyList()
            {
                _myCount = ++MyList<object>._count;
    
            }
            public int GetCount()
            {
                return _myCount;
            }
        }
    }
