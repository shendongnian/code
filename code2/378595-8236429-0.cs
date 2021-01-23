    public class ReadonlyTestClass {
     private readonly object _name;
     public ReadonlyTestClass(object name) {
       _name = name;
     }
     public object Name {get { return _name; }}
    }
