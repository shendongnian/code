    // Dont use this class
    // public class DataFields : List<DataField>
    // {
    // }
    
    public abstract class DataField
    {
        public string Name { get; set; }
    }
    
    public class DataField<T> : DataField
    {
        public T Value { get; set; }
    }
    
    public static List<DataField> ConvertXML(XMLDocument data) {  //return List<DataField>
         result = (from d in XDocument.Parse(data.OuterXML).Elements()
                          select new DataField<string>
                          {
                              Name = d.Name.ToString(),
                              Value = d.Value
                          }).Cast<DataField>().ToList();  // use cast
        return result;
    }
