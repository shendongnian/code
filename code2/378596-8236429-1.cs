    public class ReadonlyTestClass {
     public ReadonlyTestClass(object name) {
       this.Name = name;
     }
     public object Name {get; private set;}
    }
