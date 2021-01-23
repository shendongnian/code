    public abstract class BaseView<TController>
    {
        protected TController Controller { get; private set; }
        protected BaseView(TController controller)
        {
           Controller = controller;
        }
    }
