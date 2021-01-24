    public abstract class AuthObject<T>
         where T : struct, IConvertible // A reasonable way to constrain to an enumeration. 
                                        // you can also use System.Enum for newer versions of .Net past 7.3 I believe. 
    {
        public T Values { get; } 
        public abstract AuthObject<T> AddPermission(T permission);
    }
    public enum Values
    {
        None = 0,
        Read = 1,
        Search = 2,
        Filter = 4,
        Export = 8
    }
    public class AuditLogManagement : AuthObject<Values>
    {
        private long _permissions;
        public AuthObject AddPermission(Values permission)
        {
            _permissions |= (long)permissions;
            return this;
        }
    }
