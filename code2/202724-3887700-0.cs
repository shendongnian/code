    try
    {
        // Set up an interprocess object which will handle instructions
        // from the client and pass them onto the main Manager object.
        this.m_ServerDomain = AppDomain.CreateDomain("roketpack_server");
        this.m_ServerDomain.DoCallBack(() =>
            {
                // We must give clients the permission to serialize delegates.
                BinaryServerFormatterSinkProvider serverProv = new BinaryServerFormatterSinkProvider();
                serverProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
                IpcServerChannel ipc = new IpcServerChannel("roketpack", "roketpack", serverProv);
                ChannelServices.RegisterChannel(ipc, true);
                RemotingConfiguration.RegisterWellKnownServiceType(
                    typeof(API.InterProcess),
                    "InterProcessManager",
                    WellKnownObjectMode.Singleton);
            });
        // Now initialize the object.
        IpcClientChannel client = new IpcClientChannel();
        ChannelServices.RegisterChannel(client, true);
        this.m_InterProcess = (API.InterProcess)Activator.GetObject(
            typeof(API.InterProcess),
            "ipc://" + name + "/InterProcessManager");
        InterProcessHandle.Manager = this;
        this.m_InterProcess.SetCalls(InterProcessHandle.CallURL,
                        InterProcessHandle.IsLatestVersion,
                        InterProcessHandle.RequestUpdate);
        return true;
    }
    catch (RemotingException)
    {
        // The server appears to be already running.  Connect to
        // the channel as a client and send instructions back
        // to the server.
        IpcClientChannel client = new IpcClientChannel();
        ChannelServices.RegisterChannel(client, true);
        API.InterProcess i = (API.InterProcess)Activator.GetObject(
            typeof(API.InterProcess),
            "ipc://" + name + "/InterProcessManager");
        if (i == null)
        {
            Errors.Raise(Errors.ErrorType.ERROR_CAN_NOT_START_OR_CONNECT_TO_IPC);
            return false;
        }
        if (Environment.GetCommandLineArgs().Length > 1)
            i.CallURL(Environment.GetCommandLineArgs()[1]);
        return false;
    }
