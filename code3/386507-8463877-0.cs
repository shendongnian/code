    [XmlRoot("movie")] 
    public class Movie {     
          [XmlElement("price")]     
          public string Price { get; set; }  
    
          [XmlIgnore]
          public double RealPrice { 
             get { 
                   double resultprice;
                   Double.TryParse(Price, 
                   NumberStyles.Any, 
                   new CultureInfo("de-DE"), resultprice);
                   return resultprice;
                  } 
           }
