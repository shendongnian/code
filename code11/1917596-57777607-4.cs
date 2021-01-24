    PropertyInfo[] properties = type.GetProperties();
    Debug.Log("Do i die here?");
    foreach (PropertyInfo property in properties)
    {
        if(!property.CanRead || !property.CanWrite) continue;
   
        property.SetValue(myNew_Component, property.GetValue(original, null), null);
    }
