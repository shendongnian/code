    public class EngDictionary
    {
        Dictionary<string, string> dictionary;
        public void EngDictionary()
       {
            dictionary = new Dictionary<string, string>();
            dictionary.Add("Classifieds", "Kleinanzeigen");
            ....
        }
      
       public Dictionary<string, string> getDictionary()
       {
             return this.dictionary;
       }
     }
