    var SomeObject = new { .../*properties*/... };
    var PropertyInfos = SomeObject.GetType().GetProperties();
    foreach(PropertyInfo pInfo in PropertyInfos)
    {
        string propertyName = pInfo.Name; //gets the name of the property
        doSomething(pInfo.GetValue(SomeObject,null));
    }
