            private async Task ConnectDevice(string name)
            {
                BluetoothDevice device = null;
                BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;
                BluetoothSocket bthSocket = null;
                BluetoothServerSocket bthServerSocket = null;
                UUID uuid = UUID.FromString("00001101-0000-1000-8000-00805f9b34fb");
                bthServerSocket = adapter.ListenUsingRfcommWithServiceRecord("TLCI Barcode Scanner", uuid);
                _cancellationToken = new CancellationTokenSource();
                while (_cancellationToken.IsCancellationRequested == false)
                {
                    try
                    {
                        Thread.Sleep(250);
                        adapter = BluetoothAdapter.DefaultAdapter;
                        if (adapter == null)
                            Debug.Write("No bluetooth adapter found!");
                        else
                            Debug.Write("Adapter found!");
                        if (!adapter.IsEnabled)
                            Debug.Write("Bluetooth adapter is not enabled.");
                        else
                            Debug.Write("Adapter found!");
                        Debug.Write("Try to connect to " + name);
                        foreach (var bondedDevice in adapter.BondedDevices)
                        {
                            Debug.Write("Paired devices found: " + bondedDevice.Name.ToUpper());
                            if (bondedDevice.Name.ToUpper().IndexOf(name.ToUpper()) >= 0)
                            {
                                Debug.Write("Found " + bondedDevice.Name + ". Try to connect with it!");
                                device = bondedDevice;
                                Debug.Write(bondedDevice.Type.ToString());
                                break;
                            }
                        }
                    
                        if (device == null)
                            Debug.Write("Named device not found.");
                        else 
                        {
                            bthSocket = bthServerSocket.Accept();
                            adapter.CancelDiscovery();
                            if (bthSocket != null)
                            {
                                Debug.Write("Connected");
                                if (bthSocket.IsConnected)
                                {
                                    var mReader = new InputStreamReader(bthSocket.InputStream);
                                    var buffer = new BufferedReader(mReader);
                                    while (_cancellationToken.IsCancellationRequested == false)
                                    {
                                        if (MessageToSend != null)
                                        {
                                            var chars = MessageToSend.ToCharArray();
                                            var bytes = new List<byte>();
                                            foreach (var character in chars)
                                            {
                                                bytes.Add((byte)character);
                                            }
                                            await bthSocket.OutputStream.WriteAsync(bytes.ToArray(), 0, bytes.Count);
                                        
                                            MessageToSend = null;
                                        }
                                    }
                                
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.Write(ex);
                        Debug.Write(ex.Message);
                    }
                    finally
                    {
                        if (bthSocket != null)
                            bthSocket.Close();
                        device = null;
                        adapter = null;
                    }
                }
            }
