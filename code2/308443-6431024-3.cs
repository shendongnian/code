     public object GetVal(string propName)
     {
         var propInfo = this.GetType().GetProperty(propName, BindingFlags.Instance);
         if(propInfo == null)
             return null;
         
         return propInfo.GetValue(this);
     }
