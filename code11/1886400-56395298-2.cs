    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace StackOverFlow
    {
        static class Program
        {
            static void Main()
            {
                List<Mobile> mobiles = new List<Mobile>
                {
                    new Mobile{Id = 1,Name = "samsung galaxy s3",Description = "model"},
                    new Mobile{Id = 2,Name = "",Description = "nokia n96 time"},
                    new Mobile{Id = 3,Name = "iphone 5s",Description = "test"},
                    new Mobile{Id = 4,Name = "samsung galaxy packet",Description = "this time"},
                    new Mobile{Id = 5,Name = "iphone ipad",Description = "now"},
                    new Mobile{Id = 6,Name = "glx c5",Description = "time"},
                };
    
                string[] search = "galaxy time 5s".Split(' ');
    
                var result = mobiles.Where(c => c.Name.ContainsAny(search) ||
                                                c.Description.ContainsAny(search)).ToList();
    
                foreach (var item in result)
                {
                    Console.WriteLine(item.Id + "-" + item.Name + "-" + item.Description);
                }
    
                Console.ReadKey();
            }
 
