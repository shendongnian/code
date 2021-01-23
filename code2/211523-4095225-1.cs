    public class Book
    {
        [XmlAttribute] 
        public string Title {get;set;}
        
        public bool ShouldSerializeTitle() {
            return !string.IsNullOrEmpty(Title);
        }
        [XmlAttribute]
        public string Description {get;set;}
        
        public bool ShouldSerializeDescription() {
            return !string.IsNullOrEmpty(Description );
        }
        [XmlAttribute]
        public string Author {get;set;}
        public bool ShouldSerializeAuthor() {
            return !string.IsNullOrEmpty(Author);
        }
        [XmlAttribute]
        public string Publisher {get;set;}
       
        public bool ShouldSerializePublisher() {
            return !string.IsNullOrEmpty(Publisher);
        }
    }
