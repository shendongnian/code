    public class YourRepositoryClass<T> where T : class, new()
    { 
       public async Task<T> Handler(List<Item>() items)
         { var newList= new List<T>();
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
