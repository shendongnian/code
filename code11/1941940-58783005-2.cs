    namespace WPFStack.Model
    {
    
        /// <summary>
        /// Class Orders which is a placeholder for Xaml example data. 
        /// </summary>
        public class Orders : List<Order> { }
        public class Order
        {
            public string CustomerName { get; set; }
            public int OrderId { get; set; }
    
            public bool InProgress { get; set; }
            
    
        }
    }
