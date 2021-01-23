    public interface ISomeObjectFactory
    {
        ISomeObject CreateSomeObject(float someValue);
    }
    public class SomeObjectFactory : ISomeObjectFactory
    {
        private IKernel kernel;
        public SomeObjectFactory(IKernel kernel) 
        {
            this.Kernel = kernel;
        }
    
        public ISomeObject Create(float someValue)
        {
            return this.kernel.Get<ISomeObject>(WithConstructorArgument("someValue", someValue);
        }
    }
