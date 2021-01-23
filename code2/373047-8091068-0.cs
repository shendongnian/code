    public class Dict {
    
       private Dictionary<string, string> dict;
       public SomeDictionary { get dict; set dict = value; }
    
       public Dict() {
          dict = new Dictionary<string, string>();
          dict.Add("Classifieds", "Kleinanzeigen");
       }
    }
