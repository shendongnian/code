    struct RegistrationInfo
    {
        public static readonly RegistrationInfo Empty = new RegistrationInfo();
        public string Username;
        public string CustomerName;
        public string Validity; 
    }
    abstract class Base
    {
        public abstract void Register(RegistrationInfo info);
    }
    class Registrar1 : Base
    {
        public override void Register(RegistrationInfo info)
        {
            if (info.Username == null) throw new ArgumentNullException("info.Username");
        }
    }
    class Registrar2 : Base
    {
        public override void Register(RegistrationInfo info)
        {
            if (info.CustomerName == null) throw new ArgumentNullException("info.CustomerName");
        }
    }
