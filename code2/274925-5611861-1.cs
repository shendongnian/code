     ...
       using (TcpClient client = new TcpClient(ipaddress, 8080) //ipaddress is the ip address of the server
      {
       BinaryFormatter formatter = new BinaryFormatter();
       formatter.Serialize(client.GetStream(), 12) //12 is an example for the integer
       bool result = formatter.Deserialize(client.GetStream());
       ... //do something with result
      }
       ...
