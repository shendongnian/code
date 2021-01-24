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
        private int _position = 0;
        public int Position 
        {
           get {return _position;}
           set {
               _position = value;
               while (_position >= 40) position -= 40;
               while (_position < 0) _position += 40; //allow for moving backwards past Go
           }
        }
    
        public string PlayerName {get;set;}
    
        public int Cash {get;set;} = 1500;
    
        public List<Property> Properties {get;} = new List<Property>();
    }
