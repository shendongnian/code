    using System.Reflection;
    
    public static Item CreateItem<Item>(object[] constructorArgs, object[] propertyVals)
    {
        //Get the object type
        Type t = typeof(Item);
        
        //Create object instance
        Item myItem = (Item)Activator.CreateInstance(t, constructorArgs);
        
        //Get and fill the properties
        PropertyInfo[] pInfoArr = t.GetProperties();
        for (int i = 0; i < pInfoArr.Length; ++i)
            pInfo.SetValue(myItem, propertyVals[i], null); //The last argument is for indexed properties
        return myItem;
    }
