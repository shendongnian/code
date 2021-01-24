        static async Task UdpClientClient(string messageToSend)
        {
            var client = new UdpClient();
            client.Connect("127.0.0.1", 33000);
            for(var i=0;i<5;i++)
            {
                var message = ASCIIEncoding.ASCII.GetBytes(messageToSend + " #"+ i.ToString());
                await client.SendAsync(message, message.Length);
                await Task.Delay(1000);
            }
        }
    }
