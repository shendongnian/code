    class DataBase
    {
        public string Name { get;  set; }
        public double Price { get;  set; }
        public double Quantity { get;  set; }
    
        public override string ToString()
        {
             return $"Name: {Name} Price: {Price} Quantity: {Quantity}";
        }
    }
    
