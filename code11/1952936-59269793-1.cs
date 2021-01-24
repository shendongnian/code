    using System;
    using System.Collections.Generic;
    
    namespace ConsoleAppCore
    {
        public static class Extension
        {
            public static List<dynamic> Where(this IEnumerable<dynamic> list, Func<dynamic, bool> func)
            {
                List<dynamic> result = new List<dynamic>();
                foreach(dynamic item in list) {
                    try {
                        if (func(item))
                            result.Add(item);
                    }
                    catch {
                        continue;
                    }
                }
                return result;
            }
        }
        class YourClass
        {
            public int x = 5;
        }
        class Program
        {
            static void Main(string[] args)
            {
                LinkedList<dynamic> list = new LinkedList<dynamic>();
                list.AddAfter(list.AddAfter(list.AddAfter(list.AddAfter(
                    list.AddAfter(list.AddAfter(list.AddAfter(list.AddFirst(
                        (decimal)1), 2), (double)3), "Hello"), 5), new YourClass()), (float)7), 8);
    
                var newlist = list.Where(i => i == "Hello");
                // only one logical operation at a time (caused exceptions break the logic)
                newlist.AddRange(list.Where(i => i.x == 5));
                newlist.AddRange(list.Where(i => i > 5));
    
                foreach(var i in newlist)
                    Console.WriteLine(i);
            }
        }
    }
