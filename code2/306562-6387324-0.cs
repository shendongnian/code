    public void LoopEverythingAndFix(object instance)
    {
        var fields = instance.GetType().GetFields(BindingFlags.Public|BindingFlags.Instance)
        foreach(var fieldInfo in fields){
           var fieldType = fieldInfo.FieldType;
           if(!fieldType.IsValueType){
              bool isString = fieldType == typeof(string);
              var fieldValue = fieldInfo.GetValue(instance);
              if(fieldValue != null){
                    if(!isString){
                        // This should recursion be called when the type is a 
                        // complex (non-string) reference type that is not null
                        LoopEverythingAndFix(fieldValue);
                    }
                    // You don't need to fix a non-null string value
              }
              else{
                  if(isString){
                      // since you didn't post the code for this, I am assuming 
                      // it works correctly, but it may be that you can just replace
                      // GetDefaultValue(fieldInfo) with string.Empty 
                      fieldInfo.SetValue(instance, GetDefaultValue(fieldInfo));
                  }
                  else{
                      // It is unclear how you want to handle a complex reference type 
                      // field with a null value.  That code should go here.
                  }
              }
           } 
        }
    }
