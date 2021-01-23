    public JsonResult Save(string typeName, string model)
    {
        // My genius answer here
        Type theType = Type.GetType(typeName);
        if (theType != null)
        {
            MethodInfo mi = typeof(JsonConvert).GetMethod("DeserializeObject");
            MethodInfo invocableMethod = mi.MakeGenericMethod(theType);
            var deserializedObject = invocableMethod.Invoke(null, model);
        }
    }
