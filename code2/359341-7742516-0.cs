    public abstract class Base
    {
       ...
       protected static readonly Dictionary<int, string> errorDescriptions;
       // Type constructor called when Type is first accessed.
       // This is called before any Static members are called or instances are constructed.
       static Base ()
       {
          errorDescriptions = new Dictionary<int, string>();
          errorDescriptions[1] = "Description1";
          errorDescriptions[2] = "Description2";
       }
    }
