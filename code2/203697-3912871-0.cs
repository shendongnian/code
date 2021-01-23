    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)] 
    public class MyService : IMyServiceContract
    {
        [OperationBehavior]
        public void MyServiceCall ()
