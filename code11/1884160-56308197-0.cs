        public partial class Order 
        {
            public Order()
            {
                this.OrderLines = new HashSet<OrderLine>();
            }
    
            public int Id { get; set; }
            public Nullable<System.DateTime> DeliveryDate { get; set; }
            public Nullable<int> CustomerId { get; set; }
            public Nullable<decimal> TotalPrice { get; set; }
    
            public virtual Customer Customer { get; set; }
            public virtual ICollection<OrderLine> OrderLines { get; set; }
        }
