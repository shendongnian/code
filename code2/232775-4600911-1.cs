    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    
    namespace ConsoleApplication3 {
    
        [XmlRoot("person")]
        public class Person {
    
            [XmlElement("firstName")]
            public string FirstName { get; set; }
    
            [XmlElement("lastName")]
            public string LastName { get; set; }
        }
    
    }
