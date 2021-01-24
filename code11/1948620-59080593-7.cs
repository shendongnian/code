    class ClassThatImplementsIAnInterface : IAnInterface
    {
        public ClassThatImplementsIPropertyThatIsAnInterface InterfaceImplmentationProperty { get; set; }
        public IPropertyThatIsAnInterface InterfaceProperty { get; set; }
    }
    class ClassThatImplementsIPropertyThatIsAnInterface : IPropertyThatIsAnInterface
    {
        public int X { get; set; }
    }
