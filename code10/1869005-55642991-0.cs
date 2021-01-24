    using System;
    using System.Collections.Generic;
    using System.Linq
    
    public class Banana
    {
        public int id { get; set; }
        public string name { get; set; }
    
        public static string GetSql(List<Banana> bananas)
        {
            string _operator = "INSERT INTO bananaTable (id, name) VALUES ";
            string _val = null;
    
            foreach (var item in bananas)
            {
                _val += $" ({item.id}, '{item.name})'";
    
                if (item != bananas.Last())
                    _val += ", ";
            }
    
            return _operator + _val + "; ";
        }
    }
