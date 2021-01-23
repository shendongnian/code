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
                MyList list1 = new MyList();
                MyList list2 = new MyList();
                MyList list3 = new MyList();
                Console.WriteLine(list1.GetCount());
                Console.WriteLine(list2.GetCount());
                Console.WriteLine(list3.GetCount());
            }
        }
        public class MyList
        {
            static int _count;
            private int _myCount;
            public MyList()
            {
                _count++;
                _myCount = _count;
            }
            public int GetCount()
            {
                return _myCount;
            }
        }
    }
