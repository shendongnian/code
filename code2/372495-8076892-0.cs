    [Serializable]
    public class MyClass
    {
         int? newProperty;
         [XmlElement("Property")]
         public string OldProperty 
         {
             get { return string.Empty; }
             set 
             { 
                 if (!newProperty.HasValue)
                 {
                      int temp;
                      if (int.TryParse(value, out temp))
                      {
                           newProperty.Value = temp;
                      }
                 }
             }
         }
    
         public int NewProperty
         {
             get { return newPropery.HasValue ? newProperty.Value : 0; }
             set { newProperty.Value = value;
         }
    } 
