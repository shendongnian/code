    public class Mileage
    {
       [XmlAttribute(AttributeName = "Unit")]
       public string Unit {get; set;}
    
       [XmlText]
       public int Mileage {get; set;}
    }
