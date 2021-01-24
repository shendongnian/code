    interface IAnInterface
    {
        IPropertyThatIsAnInterface InterfaceProperty { get; set; }
    }
    interface IPropertyThatIsAnInterface
    {
        int X { get; set; }
    }
    class ClassThatImplementsIAnInterface : IAnInterface
    {
        public IPropertyThatIsAnInterface InterfaceProperty { get; set; }
    }
