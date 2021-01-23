    using System;
    using System.Linq;
    
    public static class Test
    {
        public static void Main()
        {
            var data = new[]
            {
                new { x = false, y = "hello" },
                new { x = true, y = "abc" },
                new { x = false, y = "def" },
                new { x = true, y = "world" }
            };
            
            var query = from d in data
                        orderby d.x, d.y
                        select d;
            
            foreach (var result in query)
            {
                Console.WriteLine(result);
            }
        }
        
    }
