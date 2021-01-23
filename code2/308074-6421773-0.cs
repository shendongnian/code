    foreach (PropertyInfo propertyInfo in (typeof(T)).GetProperties()){
        foreach (object attribute in propertyInfo.GetCustomAttributes(true))
        {
            if ( attribute is OnlyShowIfValueIsNonZero )
            {
               ......
            }
        }
    }
