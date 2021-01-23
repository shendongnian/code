    enter  public class Container
    {
        private IPersona _persona;
        public Container(IPersona persona)
        {
            _persona = persona;
        }
        public void AnotherMethod(Func<MyClass<IMyInterface>> myFunc)
        {
            _persona.somemethod = myFunc;
        }      
    }
