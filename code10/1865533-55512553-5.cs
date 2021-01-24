    public class SomeClassBase : ISomeClassBase 
    {
     public IMySessionBase _mySession ;
     public SomeClassBase ( IMySessionBase session)
     {
       _mySession=session;
       _mySession.connect();  // Needed??
     }
    
     public void doSomething()
     {
      _mySession.doSomething();
     }
    }
     public class SomeClassDerived : , ISomeClassDerived  
    {
     public IMySessionDerived _mySession = MySession.Instance();
     private SomeClassBase _baseClassInstance;
     public SomeClassDerived ()
     {
       _baseClassInstance=new SomeClassBase(_mySession);
        //_mySession.connect();
     }
    
     public void doSomethingElse()
     {    
      _baseClassInstance.doSomethingElse();
     }
    }
