    using System.Reflection;
    var customAttributes = property.GetCustomAttributes<MongoDBFieldAttribute>();
    foreach (var attribute in customAttributes)
    {
        dicRelation[attr.Field] = property.Name;
    }
