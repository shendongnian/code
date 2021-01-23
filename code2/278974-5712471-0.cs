    [XmlRootAttribute("ArrayOfStocks")]
    public class Stocks 
    {     
        [XmlArrayItem(typeof(Stock))]     
        public Stock[] Stocks { get; set; }  
    }
    public class Stock
    {
        public StockID { get; set; }
    
        public Description { get; set; }
    }
        public class Message
        {
            public Stocks { get; set; }
               
            public static Message Load( string xml )
            {
                    var deserializer = new XmlSerializer( typeof( Stocks ) );
                    Stocks stocks = null;
                    using( TextReader textReader = new StringReader( data ) )
                    {
                        stocks = (Stocks)deserializer.Deserialize( textReader );
                    }
        
                    return stocks;
            }
        }
