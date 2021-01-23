    ...
    TcpListener listener = new TcpListener(8080);
    listener.Start();
    using  (TcpClient client = listener.AcceptTcpClient())
    {
        BinaryFormatter formatter = new BinaryFormatter();
        //Assuming the client is sending an integer
        int arg = (int)formatter.Deserialize(client.GetStream());
        ... //Do something with arg
        formatter.Serialize(result); //result is your boolean answer
    } 
    ...
