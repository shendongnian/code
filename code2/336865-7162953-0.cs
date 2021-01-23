    public class Cat
    {
          public Id { get;set;}
          public Name { get;set;}
    
         public override string ToString()
         {
             return this.Name;
          }
    
    }
    
    private void getcategorynames()
         { 
            var categorytypes = (from categories in age.categories
                           select categories.category_Name).ToList();
    
    
            foreach (var c in categorytypes.select(p=> new Cat { Id = p.category_Id, Name = p.category_Name}))
            {
    
                listcategories.Items.Add(c);
    
    
            }
