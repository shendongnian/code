    [Serializable]
    public class OrderViewModel
    {
        public int? OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
    
        public AddressViewModel Address { get; set;}
        public ICollection<OrderLineViewModel> OrderLines { get; set; } = new List<OrderLineViewModel>();
    }
    
    [Serializable]
    public class AddressViewModel
    {
        public string Street { get; set; }
        public string City { get; set; }
        // ...
    }
    
    [Serializable]
    public class OrderLineViewModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
