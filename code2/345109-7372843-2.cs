    public class Movie
    {
       // Serialize the price field as an attribute with the given namspace
       [XmlAttribute( Namespace ="www.diranieh.com")]
       public decimal price;
    
       //serialize as <MovieName>
       [XmlElement("MovieName")]
       public string Title;
    
       // dont serialize this
       [XmlIgnore]
       public int Rating;
    
    }
