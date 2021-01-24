    var type = typeof(ModelType);
 
    var propNames = Enum.GetValues(type)
        .Cast<ModelType>()
        .Where(x => x > ModelType._NA)  // filter
        .Select(x => x.ToString())
        .ToArray();
  
    var attributes = propNames
        .Select(n => type.GetMember(n).First())
        .SelectMany(member => member.GetCustomAttributes(typeof(DescriptionAttribute), true).Cast<DescriptionAttribute>())
        .ToList();
    return attributes.Select(x => x.Description);
