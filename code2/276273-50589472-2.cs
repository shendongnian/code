    public void ProcessModel(IKernel kernel, ComponentModel model)
    {
        if (...)
        {
            var options = model.ObtainProxyOptions();
            options.Selector = new InstanceReference<IInterceptorSelector>(selector);
        }
    }
