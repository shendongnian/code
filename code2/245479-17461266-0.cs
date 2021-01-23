            IPAddress nReceiveAddress = IPAddress.Parse(GetIp(sSource));
            IPEndPoint localEndPoint = new IPEndPoint(nReceiveAddress, GetPort(sSource));
            Socket nSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            nSocket.Bind(localEndPoint);
            
            nSocket.Listen(10);
            Socket nSocketClient = nSocket.Accept();
                    byte[] bufferOne = new byte[1];
                    int nBytes = nClient.Receive(bufferOne);
                    if (nBytes == 0)
                    {
                        AppendToLog(String.Format("{0}: Closing.", sName));
                        nClient.Close();
                    }
                    else
                    {
                        byte[] buffer = null;
                        buffer = new byte[nClient.Available + 1];
                        if (nClient.Available > 0)
                            nBytes = nClient.Receive(buffer);
                        if(nBytes>0)
                        {
                            //KS effectively insert the first received byte at start.
                            Array.Copy(buffer, 0, buffer, 1, buffer.Length - 1);
                            buffer[0] = bufferOne[0];
                        }
                    }
