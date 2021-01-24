    public enum Values {
    	None = 0,
        Read = 1,
        Search = 2,
        Filter = 4,
        Export = 8
    }
    
    public abstract class AuthObject {
      public Values Value;
      public abstract AuthObject AddPermission(Values permission);
    }
    
    public class AuditLogManagement : AuthObject {
      private long _permissions;
      private Values _values;
    
      public override AuthObject AddPermission(Values permission) {
        _permissions |= (long)permission;
        return this;
      }
    }
