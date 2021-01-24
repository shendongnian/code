    Mod mod = new Mod();
    
    var modDictionary = mod.GetType().GetProperties(BindingFlags.Public).ToDictionary(
            propertyInfo => propertyInfo.Name,
            propertyInfo => propertyInfo.GetValue(mod));
