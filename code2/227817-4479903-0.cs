    public class ContainerClass
    {
        private ContainerClass() { // hide the public ctor
            throw new InvalidOperationException("no you don't");
        }
        public class SomeType
        {
            ...
        }
    }
