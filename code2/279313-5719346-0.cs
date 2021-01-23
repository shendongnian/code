    public interface MBaseObject { }
    public static class BaseObjectCode {
      public static void SomeGenericBaseObjectMethod(this MBaseObject self) {
        // ...
      }
    }
    public interface MCouchDbObject { }
    public static class CouchDbObjectCode {
      public static void SomeCouchDbSpecificMethod(this MCouchDbObject self) {
        // ...
      }
    }
    public class CashRegister : MBaseObject, MCouchDbObject { 
      // ...
    }
