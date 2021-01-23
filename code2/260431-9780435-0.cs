    using System.ComponentModel;
    // Get the attributes for the property.
    AttributeCollection attributes = 
       TypeDescriptor.GetProperties(this)["MyProperty"].Attributes;
    
    // Check to see whether the value of the ReadOnlyAttribute is Yes.
    if(attributes[typeof(ReadOnlyAttribute)].Equals(ReadOnlyAttribute.Yes)) {
       // Insert code here.
    }
