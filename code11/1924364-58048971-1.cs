csharp
private static bool TryConnect(string IP, int Port, int WaitTime)
        {
            int RunEvery = 500;
            for (int i = 0; i <= WaitTime/3; i += RunEvery)
            {
                TcpClient client = new TcpClient();
                try
                {
                    client.Connect(IP, Port);
                    Console.WriteLine(IP + ":" + Port + " is active");
                    return true;
                }
                catch(SocketException e)
                {
                    Console.WriteLine("Connection could not be established due to: \n" + e.Message);                    
                    Thread.Sleep(RunEvery);
                }
                finally
                {
                    client.Close();
                }
            }
            return false;
        }
