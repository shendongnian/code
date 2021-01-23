    Ice.Properties properties = Ice.Util.createProperties();
    properties.setProperty("Ice.MessageSizeMax", "2097152");//2gb in kb
    Ice.InitializationData initData = new Ice.InitializationData();
    initData.properties = properties;
    Ice.Communicator communicator = Ice.Util.initialize(initData);
