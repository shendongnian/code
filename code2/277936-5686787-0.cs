    public interface ISomeInterface { }
    public class SomeInterfaceFactory
    {
       private class SomeClass : IAnInterface { }
       
       public ISomeInterface Create() { return new SomeClass(); }
    }
