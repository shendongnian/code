     public class Program {
            public static void Main(string[] args) {
    
    
                string xml = @"<xml><person><firstName>Bob</firstName><lastName>Robby</lastName></person></xml>";
    
                var doc = XElement.Parse(xml);
                var person = (from x in doc.Elements("person") select x).FirstOrDefault();
    
                XmlSerializer serializer = new XmlSerializer(typeof(Person));
    
                var sr = new StringReader(person.ToString());
                // Use the Deserialize method to restore the object's state.
                var myPerson = (Person)serializer.Deserialize(sr);
    
            }
    
        }
