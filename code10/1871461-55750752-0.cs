    public async void AwaitDiscoveryReply()
          {
              try
            {
                using (var client = new UdpClient(4568,AddressFamily.InterNetworkV6))
                {
                    
                        var result = await client.ReceiveAsync();
                        Debug.WriteLine("Received DR");
                        var stateProtocol = StateProtocol.FromBytes(result.Buffer);
                        var robeatsDevice = new RobeatsDevice
                        {
                            Id = stateProtocol.DeviceId,
                            Name = stateProtocol.DeviceName,
                            EndPoint = client.Client.RemoteEndPoint,
                            StateProtocol = stateProtocol
                        };
                        OnDiscoveryReply(new DeviceDiscoveryEventArgs {RobeatsDevice = robeatsDevice});
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
