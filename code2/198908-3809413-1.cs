    public IEnumberable<Result> GetAttributesFromClass(TestClass t)
    {
   
        foreach(var property in t.GetType().GetProperties())
        {
            foreach(Author author in property.GetCustomAttributes(typeof(Arthor), true))
            {
                 // now you have an author, do what you please
                 var version = author.version;
                 var authorName = author.name;
                 // You also have the property name
                 var name = property.Name;
                 // So with this information you can make a custom class Result, 
                 // which could contain any information from author, 
                 // or even the attribute itself
                 yield return new Result(name,....);
            }
    
        }
    }
