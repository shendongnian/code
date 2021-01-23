    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
     
     
    namespace Test{
        public class Test{
            public static void Main(){
                IList<int> mylist = new List<int>();
                for(int i=0; i<10; i++) mylist.Add(i);
                var sorted = mylist.OrderBy( x => -x );
                foreach(int x in sorted)
                    Console.WriteLine(x);
            }
        }
    }
