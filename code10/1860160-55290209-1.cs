    public class MultiDoc
    {
         private XmlDocument xml = new XmlDocument();
         private string type = "";
         public void Load(string content)
         {
              //do your checking to match the types here
         }
    
         public T Get<T>()
         {
              if(typeof(T) == typeof(XmlDocument))
                  return xml;
              elseif ...
         }
    
         //implicit casting type XmlDocument
         public MultiDoc(XmlDocument input) {  xml = input; type = "xml"; }
         public static implicit operator MultiDoc(XmlDocument input) { return new MultiDoc(input); }
    
        //do same casting for other types.
    
    }
