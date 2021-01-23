    //Represents each property to show in the control, required since 
    //PropertyDescriptor is declared abstract
    public class MyPropertyDescriptor : PropertyDescriptor
    {
      public MyPropertyDescriptor(string name, Attribute[] attrs) : base(name, attrs)
      {
      }
    }
        
    //This is the class that is bound to the PropertyGrid. Using 
    //CustomTypeDescriptor instead of ICustomTypeDescriptor saves you from 
    //having to implement all the methods in the interface which are stubbed out
    //or default to the implementation in TypeDescriptor
    public class MyClass : CustomTypeDescriptor
    {
       //This is the property that controls what other properties will be 
       //shown in the PropertyGrid,  by attaching the RefreshProperties 
       //attribute, this will tell  the PropertyGrid to query the bound 
       //object for the list of properties to show by calling your implementation
       //of GetProperties 
       [RefreshProperties(RefreshProperties.All)]
       public int ControllingProperty { get; set; }
       //Dependent properties that can be dynamically added/removed
       public int SomeProp { get; set; }
       public int SomeOtherProp { get; set; }
       //Return the list of properties to show 
       public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
       {
          List<MyPropertyDescriptor> props = new List<MyPropertyDescriptor>();
          //Insert logic here to determine what properties need adding to props
          //based on the current property values
          return PropertyDescriptorCollection(props.ToArray());
       }
    }
