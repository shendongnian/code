        public static Object GetObject(Type type) 
        {
            try {
                if(_wellKnownTypes == null) {
                    InitTypeCache();
                }
                WellKnownClientTypeEntry entr = (WellKnownClientTypeEntry)_wellKnownTypes[type];
                if(entr == null) {
                    throw new RemotingException("Type not found!");
                }
                return System.Activator.GetObject(entr.ObjectType, entr.ObjectUrl);
            } catch(System.Net.Sockets.SocketException sex) {
                DebugHelper.Debug.OutputDebugString("SocketException occured in RemotingHelper::GetObject().  Error: {0}.", sex.Message);
                Disconnect();
                if(Connect()) {
                    return GetObject(type);
                }
            }
            return null;
        }
        private static void InitTypeCache() 
        {
            if(m_AdvertiseServer == null) {
                throw new RemotingException("AdvertisementServer cannot be null when connecting to a server.");
            }
            _wellKnownTypes = new Dictionary<Type, WellKnownClientTypeEntry>();
            Dictionary<string, object> channelProperties = new Dictionary<string, object>();
            channelProperties["port"] = 0;
            channelProperties["name"] = m_AdvertiseServer.ChannelName;
            Dictionary<string, object> binFormatterProperties = new Dictionary<string, object>();
            binFormatterProperties["typeFilterLevel"] = "Full";
            if(Environment.UserInteractive) {
                BinaryServerFormatterSinkProvider binFormatterProvider = new BinaryServerFormatterSinkProvider(binFormatterProperties, null); 
                _serverChannel = new TcpServerChannel(channelProperties, binFormatterProvider);
                // LEF: Only if we are coming form OUTSIDE the SERVICE do we want to register the channel, since the SERVICE already has this
                //      channel registered in this AppDomain.
                ChannelServices.RegisterChannel(_serverChannel, false);
            }
            
            System.Diagnostics.Debug.Write(string.Format("Registering: {0}...\n", typeof(IPawnStatServiceStatus)));
            RegisterType(typeof(IPawnStatServiceStatus),m_AdvertiseServer.RunningStatusURL.ToString());
            System.Diagnostics.Debug.Write(string.Format("Registering: {0}...\n", typeof(IPawnStatService)));
            RegisterType(typeof(IPawnStatService),      m_AdvertiseServer.RunningServerURL.ToString());
            System.Diagnostics.Debug.Write(string.Format("Registering: {0}...\n", typeof(IServiceConfiguration)));
            RegisterType(typeof(IServiceConfiguration), m_AdvertiseServer.RunningConfigURL.ToString());
        }
        [SecurityPermission(SecurityAction.Demand, Flags=SecurityPermissionFlag.RemotingConfiguration, RemotingConfiguration=true)]
        public static void RegisterType(Type type, string serviceUrl)
        {
            WellKnownClientTypeEntry clientType = new WellKnownClientTypeEntry(type, serviceUrl);
            if(clientType != RemotingConfiguration.IsWellKnownClientType(type)) {
                RemotingConfiguration.RegisterWellKnownClientType(clientType);
            }
            _wellKnownTypes[type] = clientType;
        }
        public static bool Connect()
        {
            // Init the Advertisement Service, and Locate any listening services out there...
            m_AdvertiseServer.InitClient();
            if(m_AdvertiseServer.LocateServices(iTimeout)) {
                if(!Connected) {
                    bConnected = true;
                }
            } else {
                bConnected = false;
            }
            return Connected;
        }
        public static void Disconnect()
        {
            if(_wellKnownTypes != null) {
                _wellKnownTypes.Clear();
            }
            _wellKnownTypes = null;
            if(_serverChannel != null) {
                if(Environment.UserInteractive) {
                    // LEF: Don't unregister the channel, because we are running from the service, and we don't want to unregister the channel...
                    ChannelServices.UnregisterChannel(_serverChannel);
                    // LEF: If we are coming from the SERVICE, we do *NOT* want to unregister the channel, since it is already registered!
                    _serverChannel = null;
                }
            }
            bConnected = false;
        }
    }
