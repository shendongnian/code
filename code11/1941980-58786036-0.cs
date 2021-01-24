    namespace Web.ViewModels.Payment
    {
        public class Items
        {
            public string licenseName { get; set; }
            public int licensePrice { get; set; }
        }
    
        public class PayerInfo
        {
            public int totalPrice { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public List<Items> Items { get; set; }
        } 
    }
