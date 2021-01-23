    class DynamicWrapper : DynamicObject {
      public object Object { get; private set; }
      public DynamicWrapper(object o) { Object = o; }
      public override bool TryGetMember(GetMemberBinder binder, out object result) {
        // Special case to be used at the end to get the actual value
        if (binder.Name == "Value") result = Object;
        // Binding on 'null' value - return 'null'
        else if (Object == null) result = new DynamicWrapper(null);
        else {
          // Binding on some value - delegate to the underlying object
          var getMeth = Object.GetType().GetProperty(binder.Name).GetGetMethod();
          result = new DynamicWrapper(getMeth.Invoke(Object, new object[0]));
        return true;
      }
      public static dynamic Wrap(object o) {
        return new DynamicWrapper(o);
      }
    }
