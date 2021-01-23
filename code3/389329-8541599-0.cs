     public class MyObjectConvert : JavaScriptConverter {
    
      public override IEnumerable<Type> SupportedTypes { get { return new Type[] { typeof(MyObjectConvert) }; }  
    
      public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer) {
    
        int TheID;
        MyObject TheObject = new MyObject();
    
        int.TryParse(serializer.ConvertToType<string>(dictionary["TheID"]), out TheID))
        TheObject.ID = TheID;
    
        if (dictionary.ContainsKey("ListOfMyNestedObject1"))
        {
          serializer.RegisterConverters(new JavaScriptConverter[] { new MyNestedObject1Convert() });
          var TheList = serializer.ConvertToType<List<MyNestedObject1>>(dictionary["ListOfMyNestedObject1"]);
          TheObject.ListOfMyNestedObject1 = TheList
        }
    
        return TheObject;
        }
    }
