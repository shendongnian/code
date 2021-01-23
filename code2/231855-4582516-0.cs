    System.Threading.Thread t = new System.Threading.Thread(() =>
                    {
                        using (System.Net.Sockets.TcpClient client = new TcpClient())
                        {
                            client.Connect("127.0.0.1", 80);
                            // Communicate with the Server. 
                        }   // The client object would be disposed here
                    });
                    t.Start();
