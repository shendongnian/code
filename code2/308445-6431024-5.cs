     public object GetVal(string propName)
     {
         var type = this.GetType();
         var propInfo = type.GetProperty(propName, BindingFlags.Instance);
         if(propInfo == null)
             throw new ArgumentException(String.Format(
                 "{0} is not a valid property of type: {1}",
                 propName, 
                 type.FullName));
         
         return propInfo.GetValue(this);
     }
