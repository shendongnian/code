                    try
                    {
                        bytesRead = nambSok.Receive(message, 4096, SocketFlags.None);
                    }
                    catch (SocketException e)
                    {
                        //a socket error has occured
                        switch (e.SocketErrorCode)
                        {
                            case System.Net.Sockets.SocketError.TimedOut:
                            case System.Net.Sockets.SocketError.WouldBlock:
                                if (doDisconnect == false)
                                {
                                    continue;
                                }
                                break;
                            case System.Net.Sockets.SocketError.ConnectionReset:
                            case System.Net.Sockets.SocketError.ConnectionAborted:
                                isConnected = false;
                                break;
                        }
                    }
                    if (bytesRead > 0)
                    {
                        /* do something with data */
                    }
