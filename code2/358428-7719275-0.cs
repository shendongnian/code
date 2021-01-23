    public class InterfaceWrapper : IInterface
    {
        private readonly SomeClass _someClass;
        public InterfaceWrapper(SomeClass someClass) { _someClass = someClass; }
        public void SomeMethod() { _someClass.SomeMethod(); }
    }
