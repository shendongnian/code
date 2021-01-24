       public static MyCheckMethod<TObj,TProp>(this TObj obj,Expression<Func<TProp>> property, TProp value)
        {
            var propertyInfo = ((MemberExpression)property.Body).Member as PropertyInfo;
            if(null != prop && prop.CanWrite)
            {
              prop.SetValue(obj, value);
            }
           //or prop.GetValue(obj);
        }
