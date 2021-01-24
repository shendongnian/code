    IPropertyThatIsAnInterface IAnInterface.InterfaceProperty
    {
        get => InterfaceImplmentationProperty;
        set
        {
            if (!(value is ClassThatImplementsIPropertyThatIsAnInterface valueAsSpecificType))
            {
                throw new ArgumentException($"{nameof(value)} is not {typeof(ClassThatImplementsIPropertyThatIsAnInterface)}", nameof(value));
            }
            InterfaceImplmentationProperty = valueAsSpecificType;
        }
    }
