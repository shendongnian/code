    public class MyService: WebService {
      
       [WebMethod()]
       [XmlInclude(typeof(StringKeyValuePair))]
       public ArrayList YourMethod() {
          //...
       }
    }
