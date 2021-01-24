    public class Order
    {
       [Key]
       public int OrderId { get; set; }
       public int OrderTypeId { get; set; }
       public string OrderNumber { get; set; }
       /* Other order fields... */
    }
    
    public class OrderType
    {
       [Key]
       public int OrderTypeId { get; set; }
       public string Name { get; set; }
    }
