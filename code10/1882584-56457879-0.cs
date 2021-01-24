                TcpClient ourTcpClient = new TcpClient();
                ourTcpClient.Connect(localIP, (int)localPort); 
                NetworkStream networkStream = ourTcpClient.GetStream();
                var sendMessageByteBuffer = Encoding.UTF8.GetBytes(testHl7MessageToTransmit.ToString());
                if (networkStream.CanWrite)
                {
                    networkStream.Write(sendMessageByteBuffer, 0, sendMessageByteBuffer.Length);
                    Console.WriteLine("Data was sent to server successfully....");
                    byte[] receiveMessageByteBuffer = new byte[ourTcpClient.ReceiveBufferSize];
                    var bytesReceivedFromServer = networkStream.Read(receiveMessageByteBuffer, 0, receiveMessageByteBuffer.Length);
                    if (bytesReceivedFromServer > 0 && networkStream.CanRead)
                    {
                        receivedMessage.Append(Encoding.UTF8.GetString(receiveMessageByteBuffer));
                    }
                    var message = receivedMessage.Replace("\0", string.Empty);
                    Console.WriteLine("Received message from server: {0}", message);
                }
              
