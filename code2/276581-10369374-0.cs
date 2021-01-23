    namespace Highrise.Model
    {
        public class Person
        {
            [XmlElement("author-id")]
            public string AuthorId
            {
                get;
                set;
            }
    
            
            [XmlElement("background")]
            public string Background
            {
                get;
                set;
            }
    
            [XmlElement("first-name")]
            public string FirstName
            {
                get;
                set;
            }
    
            [XmlElement("last-name")]
            public string LastName
            {
                get;
                set;
            }
            
            [XmlElement("id")]
            public string Id
            {
                get;
                set;
            }
            
        }
    
        public class People : List<Person>{}
    }
