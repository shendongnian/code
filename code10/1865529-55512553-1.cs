    public class SomeClassDerived : SomeClassBase, ISomeClassDerived  
    {
     public SomeClassDerived ()
     {
      _mySession = MySession.Instance(); //Declaration comes from base class automatically
      _mySession.connect();
     }
    
     public void doSomethingElse()
     {    
      _mySession.doSomethingElse();
     }
    }
