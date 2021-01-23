    [ToolboxData("<{0}:MyControl runat="server"></{0}:MyControl>"),
    Designer(typeof(MyControlDesigner))]
    public class MyControl : TextBox
    {
        // ...
    }
    
    public class MyControlDesigner : ...
    {
        // ...
    
        protected override void PreFilterProperties(
                                 IDictionary properties) 
        {
            base.PreFilterProperties (properties);
            
            // add the names of proeprties you wish to hide
            string[] propertiesToHide = 
                         {"MyProperty", "ErrorMessage"};  
            
            foreach(string propname in propertiesToHide)
            {
                prop = 
                  (PropertyDescriptor)properties[propname];
                if(prop!=null)
                {
                    AttributeCollection runtimeAttributes = 
                                               prop.Attributes;
                    // make a copy of the original attributes 
    
                    // but make room for one extra attribute
    
                    Attribute[] attrs = 
                       new Attribute[runtimeAttributes.Count + 1];
                    runtimeAttributes.CopyTo(attrs, 0);
                    attrs[runtimeAttributes.Count] = 
                                    new BrowsableAttribute(false);
                    prop = 
                     TypeDescriptor.CreateProperty(this.GetType(), 
                                 propname, prop.PropertyType,attrs);
                    properties[propname] = prop;
                }            
            }
        }
    }
