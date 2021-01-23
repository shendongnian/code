                public void get_data_from_server()
                        {
                            try
                            {
                                while (true)
                            {
              
                                    byte[] b = new byte[1024];
                                    int r = SocClient.Receive(b);
                                    if (r > 0)
                                    {
                                        this.Invoke((MethodInvoker)delegate
                                        {
                                            listBoxclient.Items.Add(Encoding.Unicode.GetString(b, 0, r));
                                            sock.Text = "socket_client == Connected";
                                            sock.ForeColor = Color.Green;
                                        });
                                    }
               
                                Thread.Sleep(400);
                                }
              
                            }
                            catch
                            {
                
                                ;
               
                            }
                        }
                    private void sending_client_to_server()
                        {
                            try
                            {
                                while (true)
                                {
                                    string datetime = gettime();
                                   string ipee =get_ip_address();
                                    byte[] b = Encoding.Unicode.GetBytes(ipee + " : " + "5050" + "  " + datetime);
                                    SocClient.Send(b);
                                    delay();
                                    Thread.Sleep(400);
                                }
                            }
                            catch
                            {
                                ;
                            }
                        }
