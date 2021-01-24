    public class MyPublisher : Publisher
    {
        public MyPublisher(ServiceFactory serviceFactory) : base(serviceFactory)
        {
            DefaultStrategy = PublishStrategy.ParallelNoWait;
        }
    }
