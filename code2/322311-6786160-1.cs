    public abstract class BaseClass
    {
        protected abstract DoProcessingImlementation();    
    
        public void DoProcessing()
        {
            // here you can add program logic or just call overridden implementation
            DoProcessingImplementation();
        }
    }
    
    public sealed class DefaultBaseClassImplementation : BaseClass
    {
        public override DoProcessingImlementation()
        {
            // default implementation of method
        }
    }
