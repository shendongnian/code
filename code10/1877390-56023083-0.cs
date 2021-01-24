    namespace Background
    {
    public enum HandshakeState { Waiting, Received, Canceled };
    public sealed class SecurepointVpnPlugin : IVpnPlugIn
    {
        DatagramSocket _datagramSocket;
        HandshakeState _handshakeState;
        public void Connect(VpnChannel channel)
        {
            string serverPort = "8000";
            string secret = "test";
            string parameters = null;
            _datagramSocket = new DatagramSocket();
            channel.AssociateTransport(_datagramSocket, null);
            _datagramSocket.MessageReceived += (s, e) =>
            {
                DataReader dataReader = e.GetDataReader();
                if (dataReader.UnconsumedBufferLength > 0 && dataReader.ReadByte() == 0)
                {
                    parameters = dataReader.ReadString(dataReader.UnconsumedBufferLength);
                    _handshakeState = HandshakeState.Received;
                }
            };
            var serverHostName = channel.Configuration.ServerHostNameList[0];
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(channel.Configuration.CustomField);
            var firstChild = xmlDocument.FirstChild;
            if (firstChild.Name.Equals("ToyVpnConfig"))
            {
                foreach (XmlNode childNode in firstChild.ChildNodes)
                {
                    if (childNode.Name.Equals("ServerPort")) serverPort = childNode.InnerText;
                    else if (childNode.Name.Equals("Secret")) secret = childNode.InnerText;
                }
            }
            _datagramSocket.ConnectAsync(serverHostName, serverPort).AsTask().GetAwaiter().GetResult();
            _handshakeState = HandshakeState.Waiting;
            HandShake(_datagramSocket, secret).AsTask().GetAwaiter().GetResult();
            if (_handshakeState == HandshakeState.Received) ConfigureAndConnect(channel, parameters);
            else channel.Stop();
        }
        public void Disconnect(VpnChannel channel)
        {
            channel.Stop();
        }
        public void GetKeepAlivePayload(VpnChannel channel, out VpnPacketBuffer keepAlivePacket)
        {
            keepAlivePacket = null;
        }
        public void Encapsulate(VpnChannel channel, VpnPacketBufferList packets, VpnPacketBufferList encapulatedPackets)
        {
            while (packets.Size > 0) encapulatedPackets.Append(packets.RemoveAtBegin());
        }
        public void Decapsulate(VpnChannel channel, VpnPacketBuffer encapBuffer, VpnPacketBufferList decapsulatedPackets, VpnPacketBufferList controlPacketsToSend)
        {            
            decapsulatedPackets.Append(encapBuffer);
        }
        IAsyncAction HandShake(DatagramSocket datagramSocket, string secret)
        {
            return Task.Run(async () =>
            {
                for (int i = 0; i < 3; i++)
                {
                    var dataWriter = new DataWriter(datagramSocket.OutputStream)
                    {
                        UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding.Utf8
                    };
                    dataWriter.WriteByte(0);
                    dataWriter.WriteString(secret);
                    await dataWriter.StoreAsync();
                    dataWriter.DetachStream();
                }
                for (int i = 0; i < 50; i++)
                {
                    await Task.Delay(100);
                    switch (_handshakeState)
                    {
                        case HandshakeState.Waiting:
                            break;
                        case HandshakeState.Received:
                            return;
                        case HandshakeState.Canceled:
                            throw new OperationCanceledException();
                        default:
                            break;
                    }
                }
            }).AsAsyncAction();
        }
        void ConfigureAndConnect(VpnChannel vpnChannel, string parameters)
        {
            parameters = parameters.TrimEnd();
            uint mtuSize = 68;
            var assignedClientIPv4list = new List<HostName>();
            var dnsServerList = new List<HostName>();
            VpnRouteAssignment assignedRoutes = new VpnRouteAssignment();
            VpnDomainNameAssignment assignedDomainName = new VpnDomainNameAssignment();
            var ipv4InclusionRoutes = assignedRoutes.Ipv4InclusionRoutes;
            foreach (var parameter in parameters.Split(null))
            {
                var fields = parameter.Split(",");
                switch (fields[0])
                {
                    case "m":
                        mtuSize = uint.Parse(fields[1]);
                        break;
                    case "a":
                        assignedClientIPv4list.Add(new HostName(fields[1]));
                        break;
                    case "r":
                        ipv4InclusionRoutes.Add(new VpnRoute(new HostName(fields[1]), (byte)(int.Parse(fields[2]))));
                        break;
                    case "d":
                        dnsServerList.Add(new HostName(fields[1]));
                        break;
                    default:
                        break;
                }
            }
            assignedRoutes.Ipv4InclusionRoutes = ipv4InclusionRoutes;
            assignedDomainName.DomainNameList.Add(new VpnDomainNameInfo(".", VpnDomainNameType.Suffix, dnsServerList, null));
            try
            {
                vpnChannel.StartExistingTransports(assignedClientIPv4list, null, null, assignedRoutes, assignedDomainName, mtuSize, mtuSize + 18, false);
            }
            catch (Exception e)
            {
                vpnChannel.TerminateConnection(e.Message);
            }
        }
    }
}
