    public class Recipient
    
        {
            public int RecipientCode { get; set; }
            public RecipientInfo RecipientNameAndAddress { get; set; }
            public IList<RecipientDelivery> Deliveries { get; set; }
        }
        
        public class RecipientInfo
        {
            public string Name { get; set; }
            public RecipientAddress Address { get; set; }
        
        }
        public class RecipientAddress
        {
            public string Line1 { get; set; }
        
            public string CityTownOrLocality { get; set; }
        
            public string StateOrProvince { get; set; }
        
            public string PostalCode { get; set; }
        }
        public class RecipientDelivery
        {
            public string DeliveryID { get; set; }
        
            public string DeliveryType { get; set; }
        
            public string DeliveryRoute { get; set; }
        
            public string ToteID { get; set; }
            public string NursingStation { get; set; }
        
        }
