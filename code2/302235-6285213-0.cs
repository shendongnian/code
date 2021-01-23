    public class ClassBeingTested
    {
        private IFactory _yourFactory;
        public ClassBeingTested(IFactory yourFactory)
        {
            _yourFactory = yourFactory;
        }
        public MethodWithDynamicInstantiation()
        {
            IClass = _yourFactory.GetClassDynamically(someparam);
        }
    }
