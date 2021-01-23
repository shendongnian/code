        TcpChannel chan = new TcpChannel(8086);
        ChannelServices.RegisterChannel(chan);
        RemotingConfiguration.RegisterWellKnownServiceType
        (Type.GetType("ClockBiometric.RequestServer"),
        "checkFingerprintTemplate", WellKnownObjectMode.Singleton);
