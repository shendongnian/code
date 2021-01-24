    public enum Status : int
    {
        Unknown = 0,
        Shipped = 1,
        Pending = 2,
        BackOrdered = 3, 
    }
    public class DatabaseRecord
    {
        public int ID { get; set; }
        public string Item { get; set; }
        public int OrderStatus { get; set; }
    }
    public class DTO
    {
        public int ID { get; set; }
        public string Item { get; set; }
        public Status OrderStatus { get; set; }         
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<DatabaseRecord> Database = new List<DatabaseRecord>()
            {
                new DatabaseRecord(){ ID = 1, Item = "Socks",   OrderStatus = 1},
                new DatabaseRecord(){ ID = 1, Item = "Shoes",   OrderStatus = 2},
                new DatabaseRecord(){ ID = 1, Item = "TShirt",  OrderStatus = 11}
            };
           
            List<DTO> DTOCollection = Database.Select(x => new DTO{
                ID = x.ID,
                Item = x.Item,
                OrderStatus = x.OrderStatus.ToEnum<Status>(Status.Unknown)               
            }).ToList();
            
            foreach(var memberOfDTO in DTOCollection)
            {
                Console.WriteLine($"{ memberOfDTO.OrderStatus }");
            }
        }
    }
    public static class Extenstions
    {
        public static T ToEnum<T>(this int integer, T defaultValue)  where T : struct, IConvertible
        {                        
            if (Enum.IsDefined(typeof(T), integer))
            {
                return (T)Enum.Parse(defaultValue.GetType(), integer.ToString());
            }
            return Activator.CreateInstance<T>();
        }
    }
