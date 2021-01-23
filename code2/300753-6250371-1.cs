       class SimpleClass{
           public int x{set; get;}
           public double y{set; get;}
       } 
        var results = new List<SimpleClass>();
        results.Add(new SimpleClass{x="test3", y=42});        
        results.Add(new SimpleClass{x="test2", y=99});
