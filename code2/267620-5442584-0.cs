      try
                                {
                                    bySent = info.Socket.Send(byTransmitBuffer);
                                }
                                catch (SocketException ex)
                                {
                                    Console.WriteLine("Only sent {0}, remaining = {1}", bySent,fs.Length -nAmount);
                                    if (ex.SocketErrorCode == SocketError.WouldBlock ||
                                      ex.SocketErrorCode == SocketError.IOPending ||
                                      ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                                    {
                                        // socket buffer is probably full, wait and try again
                                        Thread.Sleep(30);
                                    }
                                    else
                                        throw ex;  // any serious error occurr
                                }
