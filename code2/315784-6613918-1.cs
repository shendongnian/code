    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    namespace WebApplication1.Data
    {
        public class MyDdlItem
        {
            public string Id { get; set; }
            public string Name { get; set; }
    
            public List<MyDdlItem> GetAll()
            {
                List<MyDdlItem> list = new List<MyDdlItem>();
                list.Add(new MyDdlItem { Id = "1", Name = "Option 1" });
                list.Add(new MyDdlItem { Id = "2", Name = "Option 2" });
                list.Add(new MyDdlItem { Id = "3", Name = "Option 3" });
                list.Add(new MyDdlItem { Id = "4", Name = "Option 4" });
                return list;
            }
        }
    }
