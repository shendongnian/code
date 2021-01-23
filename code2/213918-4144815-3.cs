    var someObject = new { .../*properties*/... };
    var propertyInfos = someObject.GetType().GetProperties();
    foreach (PropertyInfo pInfo in PropertyInfos)
    {
        string propertyName = pInfo.Name; //gets the name of the property
        doSomething(pInfo.GetValue(someObject,null));
    }
