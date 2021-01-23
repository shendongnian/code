    this.Kernel.Components.Add<IActivationStrategy, ActivationNotificationActivationStrategy>();
    this.Kernel.Components.GetAll<IActivationStrategy>()
        .OfType<ActivationNotificationActivationStrategy>()
        .Single().Activated += ...
    public class ActivationNotificationActivationStrategy : NinjectComponent, IActivationStrategy
    {
        public event Action<object> Activated;
            
        public void Activate(IContext context, InstanceReference reference)
        {
            if (this.Activated != null)
            {
                this.Activated(reference.Instance);
            }
        }
        public void Deactivate(IContext context, InstanceReference reference)
        {
        }
    }
