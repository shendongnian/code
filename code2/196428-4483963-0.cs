    public class NonWebRunAtStartup : IRunAtStartup
    {
        public void InitializeInfrastructure(object container)
        {
            Configure.With()
                .StructureMapBuilder((IContainer) container)
                .Log4Net()
                .XmlSerializer()
                .MsmqTransport()
                .UnicastBus()
                .LoadMessageHandlers()
                .CreateBus()
                .Start();
        }
    }
