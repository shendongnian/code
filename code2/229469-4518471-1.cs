    public class MyAttribute : Attribute, IValidableAnnotation
    {
        private string propertyName;
        public MyAttribute(string propertyName)
        {
           this.propertyName = propertyName;
        }
        public bool CompileTimeValidate( object target )
        {
           PropertyInfo targetProperty = (PropertyInfo) target;
           if ( targetProperty.Name != propertyName )
           {
              Message.Write( Severity.Error, "MY001", 
                 "The custom attribute argument does not match the property name.");
              return false;
           }
        }
    }
