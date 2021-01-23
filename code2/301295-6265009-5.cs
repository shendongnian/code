    builder.RegisterType<ServiceBase>().OnActivating(e =>
    {
        var type = 
           typeof(GenericImpl<>).MakeGenericType(e.Instance.GetType());
        e.Instance.SomeInterface = (ISomeInterface)e.Context.Resolve(type);
    });
