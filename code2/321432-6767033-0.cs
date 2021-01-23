        public DspServiceMediator( String serviceAddress)
        {
            EndpointAddress end_point = new EndpointAddress(serviceAddress);
            NetTcpBinding new_tcp = new NetTcpBinding(SecurityMode.None);
            new_tcp.ReceiveTimeout = TimeSpan.MaxValue;
            new_tcp.SendTimeout = new TimeSpan(0, 0, 30); //30 seconds
            //_channelFactory = new ChannelFactory<DspServiceClient>(new_tcp, end_point);
            _dspClient = new DspServiceClient(new_tcp, end_point);
        }
