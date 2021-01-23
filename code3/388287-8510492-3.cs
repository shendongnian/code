    public class OtherClass
    {
        public static void DoSomething(CommonObject o)
        {
            // code here
        }
    }
    public interface CommonObject
    {
        string Name { get; }
        string Signature { get; }
        string Checksum { get; }
    }
    public class X : CommonObject
    {
        private string _name = "";
        private string _signature = "";
        private string _checksum = "";
        string CommonObject.Name { get { return _name; } }
        string CommonObject.Signature { get { return _signature; } }
        string CommonObject.Checksum { get { return _checksum; } }
    }
