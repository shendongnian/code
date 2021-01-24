    try
                    {
                        var connectivityManager = Android.App.Application.Context.GetSystemService(Context.ConnectivityService) as ConnectivityManager;
                        WifiManager wifiManager = (WifiManager)Android.App.Application.Context.GetSystemService(Context.WifiService);
                        if (!wifiManager.IsWifiEnabled)
                        {
                            Forms.Context.StartActivity(new Intent(Android.Provider.Settings.ActionWifiSettings));
                            return false;
                        }
    
                        var callback = new NetworkCallback(connectivityManager)
                        {
                            NetworkAvailable = network =>
                            {
                                Console.WriteLine("Connected");
                                MessagingCenter.Send<string, Boolean>("ConnectModel", "connecttowifi", true);
                            },
                            NetworkUnavailable = () =>
                            {
                                Console.WriteLine("Not Connected");
                                MessagingCenter.Send<string, Boolean>("ConnectModel", "connecttowifi", false);
                            }
                        };
                        var specifier = new WifiNetworkSpecifier.Builder()
                        .SetSsid(ssid)
                        .SetWpa2Passphrase(password)
                        .Build();
                        var request = new NetworkRequest.Builder()
                            .AddTransportType(TransportType.Wifi)
                            //.AddCapability(NetCapability.Internet)
                            //.RemoveCapability(NetCapability.Internet)
                            .SetNetworkSpecifier(specifier)
                            .Build();
                        connectivityManager.RequestNetwork(request, callback);
                        
                        return true;
                    }
                    catch (Exception e)
                    {
                        Console.Write(e.Message);
                        return false;
                    }
