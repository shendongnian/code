    class MyClass {
      ...
      public static MyClass Deserialize(string xmlContents) {
        var local = ... // Do the XML deserialization
        local.PostCreateLogic();
        return local;
      }
    }
