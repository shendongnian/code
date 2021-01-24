    public abstract class AuthObject<T>
    {
        public abstract AuthObject<T> AddPermission(T permission);
    }
    public class AuditLogManagement : AuthObject<Values>
    {
        private Values _permissions;
        public override AuthObject<Values> AddPermission(Values permission)
        {
            _permissions |= permission;
            return this;
        }
    }
    [Flags]
    public enum Values
    {
        None = 0,
        Read = 1,
        Search = 2,
        Filter = 4,
        Export = 8
    }
