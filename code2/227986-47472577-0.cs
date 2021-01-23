                    new NetNamedPipeBinding
                    {
                        MaxReceivedMessageSize     = 524288000,
                        ReceiveTimeout             = TimeSpan.MaxValue, // never timeout
                        SendTimeout                = TimeSpan.MaxValue, // never timeout
                        ReaderQuotas               =
                        {
                            MaxStringContentLength = 655360000
                        },
                        TransferMode               = TransferMode.Streamed,
                        Security = new NetNamedPipeSecurity
                        {
                            Mode = NetNamedPipeSecurityMode.None,
                            Transport = new NamedPipeTransportSecurity
                            {
                                ProtectionLevel = ProtectionLevel.None
                            }
                        }
                    }
