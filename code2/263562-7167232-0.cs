    DeviceNetworkInformation.ResolveHostNameAsync(
                new DnsEndPoint("microsoft.com", 80), 
                new NameResolutionCallback(nrr =>
                    {
                        var info = nrr.NetworkInterface;
                        var type = info.InterfaceType;
                        var subType = info.InterfaceSubtype;
                    }), null);
