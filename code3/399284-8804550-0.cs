    public class SuperA : Container 
    {
        public string IdType { get { return IdTypeFactory.Get( GetType() ); } }
    }
    public static class IdTypeFactory
    {
        public static string Get( Type containerType ) { ... }
    }
