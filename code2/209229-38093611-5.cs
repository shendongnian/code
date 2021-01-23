    public class SomeClass
    {
       private Lazy<string> _someVariable = new Lazy<string>(SomeClass.IOnlyWantToCallYouOnce);
       public string SomeVariable => _someVariable.Value;
    }
    
