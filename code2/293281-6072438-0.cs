    public class GetData
    {
        private IConnection conn = ContainerManager.Instance.Resolve<IConnection>();
        //where ContainerManager.Instance points to the container instance
        ...
    }
