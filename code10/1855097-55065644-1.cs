       public static void MyCheckMethod<TObj,TProp>(this TObj obj,Expression<Func<TObj,TProp>> property, TProp value)
        {
            var propertyInfo = ((MemberExpression)property.Body).Member as PropertyInfo;
            if(null != propertyInfo && propertyInfo.CanWrite)
            {
              propertyInfo.SetValue(obj, value);
            }
           //or propertyInfo.GetValue(obj);
        }
