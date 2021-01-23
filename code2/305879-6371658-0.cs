    public class SampleInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Kernel.AddHandlerSelector(new InvoiceHandlerSelector());
        }
        public class InvoiceHandlerSelector: IHandlerSelector
        {
            // ...
        }
    }
