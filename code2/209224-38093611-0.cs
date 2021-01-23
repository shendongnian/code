    public class SomeClass
    {
       private string _SomeVariable
       public string SomeVariable
       {
          get
          {
             if(_SomeVariable == null)
             {
                _SomeVariable = SomeClass.IOnlyWantToCallYouOnce();
             }
             return _SomeVariable;
           }
       }
    }
