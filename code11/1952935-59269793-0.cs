    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleAppCore
    {
        class Program
        {
            static void Main(string[] args)
            {
                LinkedList<int> list = new LinkedList<int>();
                list.AddAfter(list.AddAfter(list.AddAfter(list.AddAfter(list.AddFirst(1), 2), 3), 4), 5);
                list.Remove(list.Single(i => i == 3));
                foreach(var item in list)
                    Console.Write(item + ", ");
            }
        }
    }
