    public class YourRepositoryClass<T> where T : class, new()
    { 
       public async Task> Handler(List() items)
         { var newList= new List();
          foreach (var item in items)
           {
             newList.Add(new Item
             {
                ID= item.ID,
                Name= item.Status,
                Retrieved= DateTime,
             });
          }
       return messages; } 
    }
