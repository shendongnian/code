    internal sealed class IgnoreJsonActionConfiguratorAttribute : Attribute, IActionConfigurator
    {
        public void Configure(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            // Here we can configure action-specific stuff on the controller
            var factories = ValueProviderFactories.Factories.Where(f => !(f is JsonValueProviderFactory)).ToList();
            controllerContext.Controller.ValueProvider = new ValueProviderFactoryCollection(factories).GetValueProvider(controllerContext);
        }
    }
