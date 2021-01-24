        private static object InternalGetMemberValue(
          object instance, 
          string memberName, 
          BindingFlags bindingAttr)
        {
            //DONE: if we have null instance or null or empty memberName we return null
            // Alternative is to throw ArgumentNullExceptio
            if ((null == instance) ||
                 string.IsNullOrEmpty(memberName)) 
              return null;    
            Type type = instance.GetType();   
            //DONE: why MemberInfo?
            FieldInfo fieldInfo = type.GetField(memberName, bindingAttr);
            //DONE: if field is static we should pass null as instance
            if (fieldInfo != null)
               return fieldInfo.GetValue(fieldInfo.IsStatic ? null : instance); 
            ProperyInfo propertyInfo = type.GetProperty(memberName, bindingAttr);
            //DONE: we can read
            //  - existing
            //  - readable
            //  - not indexer
            // property 
            if (propertyInfo != null && 
                propertyInfo.CanRead &&
               !propertyInfo.GetIndexParameters().Any)
              return propertyInfo.GetValue(propertyInfo.IsStatic ? null : instance); 
            return null;
        }
