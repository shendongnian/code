    public class SomeClassDerived : SomeClassBase, ISomeClassDerived  
    {
        IMySessionDerived _derivedSessionAccessor=>  _mySession as IMySessionDerived;
    
    }
