    public class KeysAndValues
    {
        public string Key;
        public string Value;
    
        public override string ToString()
        {
           return string.Format("{0}: {1}", Key, Value);
        }
    }
    
    List<KeysAndValues> dict = new List<KeysAndValues>();
    foreach (XmlNode node in relatoriosStaticos.DocumentElement.ChildNodes)
    {
        dict.Add(new KeysAndValues() 
        {
            Key = node.Attributes["Titulo"].InnerText,
            Value = string.Concat(node.Attributes["Url"].InnerText, id)
        });
    }
