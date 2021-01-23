     public class TestDictionary 
        {
            public void Test()
            {
                Dictionary<Product, int> dict=new Dictionary<Product, int>();
                dict.Add(new Product(){Data = 1}, 1);
                dict.Add(new Product() { Data = 2 }, 2);
                dict.Add(new Product() { Data = 3 }, 3);
                dict.Add(new Product() { Data = 4 }, 9);
                dict.Add(new Product() { Data = 5 }, 5);
                dict.Add(new Product() { Data = 6 }, 6);
    
                var query=(from c in dict 
                    orderby c.Value descending 
                    select c.Key).ToList();       
            }
            [DebuggerDisplay("{Data}")]
            public class Product
            {
                public int Data { get; set; }
            }           
        }
