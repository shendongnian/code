    Mod mod = new Mod();
    
    var modDictionary = mod.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
             .ToDictionary(
               propertyInfo => propertyInfo.Name,
               propertyInfo => propertyInfo.GetValue(mod));
