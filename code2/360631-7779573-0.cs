    class abc<T> {
      private T foo; 
      public string a {
        set {
          var x_type = typeof(T);
          foo = (T)x_type.InvokeMember("Parse", System.Reflection.BindingFlags.InvokeMethod, null, value, new []{value});
        }
    
        get{
           return foo.ToString();
        }
      }
    }
