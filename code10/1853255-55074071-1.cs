    public class HandleClient
        {
            private TcpClient clientSocket;
            private static int bufferLength = 1024;
            private byte[] readBuffer = new byte[bufferLength];
    
            public void StartClient(TcpClient inClientSocket)
            {
                this.clientSocket = inClientSocket;
    
                var ctThread = new Thread(Chat);
                ctThread.Start();
            }
    
            private void Chat()
            {
                var reader = clientSocket.GetStream();
    
                try
                {
                    while (true)
                    {
                        var bytesRead = reader.Read(readBuffer, 0, bufferLength);
    
                        using (var memoryStream = new MemoryStream())
                        {
                            memoryStream.Write(readBuffer, 0, bytesRead);
                            var message = System.Text.Encoding.ASCII.GetString(memoryStream.ToArray());
    
                            Log.Debug("Server got this message from client: {message}", message);
    
                            foreach (TcpClient client in Program.GetClients())
                            {
                                var writer = new BinaryWriter(client.GetStream());
                                writer.Write($"Server got your message '{message}'");
                            }
                        }
                    }
                }
                catch (EndOfStreamException)
                {
                    Log.Error($"client disconnecting: {clientSocket.Client.RemoteEndPoint}");
                    clientSocket.Client.Shutdown(SocketShutdown.Both);
                }
                catch (IOException e)
                {
                    Log.Error($"IOException reading from {clientSocket.Client.RemoteEndPoint}: {e.Message}");
                    Console.WriteLine();
                }
                catch (ObjectDisposedException e)
                {
                    Log.Error(e, "Error (ObjectDisposedException) receiving from server");
                }
                catch (Exception e)
                {
                    Log.Error(e, "Error receiving from server");
                }
    
                clientSocket.Close();
                Program.RemoveClient(clientSocket);
                Log.Debug("{count} clients connected", Program.GetClientCount());
            }
        }
