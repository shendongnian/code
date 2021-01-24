        public interface IMyCloudQueueCollection
        {
            CloudQueue StartRenderQueue { get; }
    
            CloudQueue RenderCompletedQueue { get; }
        }
    
        public class MyCloudQueueCollection : IMyCloudQueueCollection
        {
            public CloudQueue StartRenderQueue { get; private set; }
    
            public CloudQueue RenderCompletedQueue { get; private set; }
    
            public MyCloudQueueCollection(CloudQueue startRenderQueue, CloudQueue renderCompletedQueue)
            {
                this.StartRenderQueue = startRenderQueue;
                this.RenderCompletedQueue = renderCompletedQueue;
            }
        }
         // in startup
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IMyCloudQueueCollection,MyCloudQueueCollection>(s=> new MyCloudQueueCollection(startRenderQueue, renderCompletedQueue))
        } 
        
         //in controller
         public RenderImageController(IMyCloudQueueCollection queueCollection)
         {
             _startRenderQueue = queueCollection.StartRenderQueue;
             _renderCompletedQueue = queueCollection.RenderCompletedQueue;
         } 
