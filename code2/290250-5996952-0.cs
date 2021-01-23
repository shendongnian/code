    public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
    {
      //...
      if (!object.ReferenceEquals(dictionary["MyProperty"],null)){
        // My Code
      }
      //...
    }
