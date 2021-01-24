    public class Order
    {
       [Key]
       public int OrderId { get; set; }
       public int OrderTypeId { get; set; }
       public string OrderNumber { get; set; }
       /* Other order fields... */
       [ForeignKey("OrderTypeId")]
       public virtual OrderType OrderType { get; set; }
    }
