     public class Cat
        {
              public int Id { get;set;}
              public string Name { get;set;}
        
             public override string ToString()
             {
                 return this.Name;
              }
        
        }
        
        private void getcategorynames()
             { 
                var categorytypes = (from categories in age.categories
                               select categories.category_Name).ToList();
        
    listcategories.SelectedIndexChanged += new EventHandler(listcategories_SelectedIndexChanged);
        
                foreach (var c in categorytypes.select(p=> new Cat { Id = p.category_Id, Name = p.category_Name}))
                {
        
                    listcategories.Items.Add(c);
        
        
                }
    
    void listcategories_SelectedIndexChanged(object sender, EventArgs e)
            {
                Cat selected = (Cat)(sender as ListBox).SelectedItem;
            }
