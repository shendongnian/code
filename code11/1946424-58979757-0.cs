    public class Property
    {
       public string Name {get;set;}
       public string Color {get;set;}
       public int PurchasePrice {get;set;}
       
       //other things like houses/hotel, mortgage, rent, etc
    }
    
    public class Player
    {
        public Label positionLabel {get; set;}
        public int Position {get;set;} = 0;
    
        public string PlayerName {get;set;}
    
        public int Cash {get;set;} = 1500;
    
        public List<Property> Properties {get;} = new List<Property>();
    }
