    public class ClientType
    {
        public string FieldOne { get; set; }
        public string FieldTwo { get; set; }
    
        public ClientType()
        {
        }
    
        public ClientType( ServiceType serviceType )
        {
            this.FieldOne = serviceType.FieldOne;
            this.FieldTwo = serviceType.FieldTwo;
        }
    }
