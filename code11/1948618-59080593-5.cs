    interface IAnInterface<TPropertyThatIsAnInterface>
        where TPropertyThatIsAnInterface : IPropertyThatIsAnInterface
    {
        TPropertyThatIsAnInterface InterfaceProperty { get; set; }
    }
