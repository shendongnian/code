    public object ToObject(DynamicType dynamicType){
    var type = Type.GetType(dynamicType.TypeName);
    // Here you could check if the json is list, its really upp to you
    // but as an example, i will still add it
    if (dynamicType.JsonString.StartsWith("[")) // its a list
        type =(List<>).MakeGenericType(type);
    return JsonConvert.DeserializeObject(dynamicType.JsonString, type);
    } 
