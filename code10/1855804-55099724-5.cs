        public class Item
        {
          public int ID { get; set; }
          public string Status { get; set; }
        }
        public interface IRepositoryClass
        {
          int ID { get; set; }
          string Name { get; set; }
          DateTime Retrieved { get; set; }
        }
        public class YourRepositoryClass<T> where T : IRepositoryClass, new()
        { 
         public async Task<IEnumerable<T>> Handler(List<Item> items)
         { 
           var newList= new List<T>();
           foreach (var item in items)
            {
             newList.Add(new T
             {
                ID= item.ID,
                Name= item.Status,
                Retrieved= DateTime,
             });
          }
       return newList; } 
    }
