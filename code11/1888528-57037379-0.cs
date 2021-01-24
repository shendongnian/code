 private TcpClient m_client;
async public void connect(string address, int port)
        {
            if(m_client.Connected)
            {
                m_client.Close();
            }
            try
            {
                await m_client.ConnectAsync(address, port);
            }catch(Exception e)
            {
                Console.WriteLine($"error while connecting: {e.Message}");
            }
            Console.WriteLine($"is connected : {m_client.Connected}");
            
        }
