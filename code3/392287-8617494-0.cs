    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    internal class User
        {
            public string ID { get; set; }
        
            public string Name { get; set; }
        }
        
        internal class Program
        {
            private static void Main(string[] args)
            {
                Dictionary<string, User> dic = new Dictionary<string, User>();
                dic.Add("1", new User { ID = "id1", Name = "name1" });
                dic.Add("2", new User { ID = "id2", Name = "name2" });
                dic.Add("3", new User { ID = "id3", Name = "name3" });
        
                User user = dic.Where(z => z.Value.ID == "id2").FirstOrDefault().Value;
        
                Console.ReadKey();
            }
        }
