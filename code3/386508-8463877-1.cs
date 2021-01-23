    [XmlRoot("movie")] 
    public class Movie {     
          [XmlElement("price")]     
          public string Price { get; set; }  
    
          [XmlIgnore]
          public double RealPrice { 
             get { 
                   double resultprice;
                   if (!Double.TryParse(
                      Price, 
                      NumberStyles.Any, 
                      new CultureInfo("de-DE"),
                      resultprice)) throw new ArgumentException("price");
                   // resultprice is now parsed, if not an exception is thrown
                   return resultprice;
                  } 
           }
