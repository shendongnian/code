    Mod mod = new Mod();
    
    var modDictionary = mod.GetType().GetProperties().ToDictionary(
            propertyInfo => propertyInfo.Name,
            propertyInfo => propertyInfo.GetValue(mod));
