    public class SomeType
    {
       public SomeType()
       {
          Properties = new List<BaseProperty>();
       }
       public int PrimaryKey { get; set; }
       public string Name { get; set; }
       public List<BaseProperty> Properties { get; set; }
       public List<BaseProperty> PropertiesAB 
       { 
          get
          {
             return Properties.Where(p=>p is PropertyA || p is PropertyB);
          } 
          set
          {
             //Remove all the properties already in the Properties collection of
             //the type A and B and then
             Properties.AddRange(value)
          } 
       }
       //Same with rest of the properties
    }
