    using System.ComponentModel;   
    public void FillMeUp(Dictionary<string, string> inputValues){
            PropertyInfo[] classProperties  = this.GetType().GetProperties();
           var properties = TypeDescriptor.GetProperties(this);
           foreach (PropertyDescriptor property in properties)
           {
               if (inputValues.ContainsKey(property.Name))
               {
                   var value = inputValues[property.Name];
                   property.SetValue(this, 
                                     property.Converter.ConvertFromInvariantString(value));
               }
           }
