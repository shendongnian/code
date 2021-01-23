    bool eq = true;
    foreach (string prop in PropertiesYouWantToCheck){
        PropertyInfo propInfo = obj1.GetType().GetProperties().Single(x => x.Name == prop);
        if(propInfo.GetValue(obj1, null) != propInfo.GetValue(obj2, null)){
            eq = false;
            break;
        }
    }
