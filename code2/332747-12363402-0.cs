    JavaScriptSerializer serializer = new JavaScriptSerializer();
    serializer.RegisterConverters(new DynamicJavaScriptConverter[] { new DynamicJavaScriptConverter() });
    var result = WrapObject(serializer.DeserializeObject(value)); // here you will have result.
    
    private object WrapObject(object value)
        {
            IDictionary<string, object> values = value as IDictionary<string, object>;
            if (values != null)
            {
                return new DynamicJsonObject(values);
            }
            object[] arrayValues = value as object[];
            if (arrayValues != null)
            {
                return new DynamicJsonArray(arrayValues);
            }
            return value;
        }
