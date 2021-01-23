    public class ServiceInstanceProvider : IInstanceProvider
    {
        public object GetInstance(InstanceContext instanceContext)
        {
            return this.GetInstance(instanceContext, null);
        }
        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return new MyService(...);
        }
        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {}
    }
