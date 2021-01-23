    public class Foo{
    
         [XmlIgnore()]
         public Dictionary<string,string> Dct{get;set;}
    
         [XmlAttribute]
         public string SerializedDictionary{
              get{
                   StringBuilder s = new StringBuilder();
                   foreach(var kvp in Dct){
                        if (s.Length > 0) s.Append("|");
                        s.AppendFormat("{0},{1}", kvp.Key, kvp.Value);
                   }
                   return s.ToString();
              }
              set{
                   string[] aKvps = value.Split('|');
                   Dct = new Dictionary<string,string>();
                   for(int i=0; i<aKvps.Length; ++i){
                        string aPair = aKvps[i].Split(',');
                        if (aPair.Length == 2)
                             Dct.Add(aPair[0], aPair[1]);
                   }
              }
         }
    
    }
