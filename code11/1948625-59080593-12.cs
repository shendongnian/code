    interface IAnInterface
    {
        IPropertyThatIsAnInterface InterfaceProperty { get; }
    }
    interface IPropertyThatIsAnInterface
    {
        int X { get; set; }
    }
    class ClassThatImplementsIAnInterface : IAnInterface
    {
        public IPropertyThatIsAnInterface InterfaceProperty { get; }
    }
