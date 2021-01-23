        public Socket getSocket1(string Hostname, int PortNmber)
        {
            TcpClient client = new TcpClient(Hostname, PortNumber);
            return client.Client;
        }
