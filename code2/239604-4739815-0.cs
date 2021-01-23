    var config = Configure.WithWeb().StructureMapBuilder(ObjectFactory.GetInstance<IContainer>()).XmlSerializer();
    config.UnicastBus().MsmqTransport();
    config.Configurer
        .ConfigureComponent<MsmqTransport>(ComponentCallModelEnum.Singleton)
        .ConfigureProperty(t => t.InputQueue, "QcQueue.Denormalizer");
    config.CreateBus().Start();
