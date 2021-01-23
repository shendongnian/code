     var propts = typeof(T).GetProperties();
     T model = new T();
       foreach (var viewFieldProperty in propts)
        {
 
                    sourceFieldName = viewFieldProperty.Name;
                  
                    Type fieldTypeSource = viewFieldProperty.PropertyType;
                    sourceFieldNameType = fieldTypeSource.ToString();
                    if(viewFieldProperty.GetAccessors()[0].IsVirtual==false) //bypass virtual collections
                    {
                    …
                      val = entityObject.GetType().GetProperty(viewFieldProperty.Name).GetValue(entityObject, null);
                      if (val != null) { viewFieldProperty.SetValue(model, val); }
                    }
         }
