    // Create a new house to send house and set values.
    var newHouse = new House
        {
            Street = "Mill Lane", 
            ZipCode = "LO1 BT5", 
            Number = 11, 
            Id = 1, 
            Town = "London"
        };  
    var xmlSerializer = new XmlSerializer(typeof(House));
    var networkStream = tcpClient.GetStream();
    if (networkStream.CanWrite)
    {
        xmlSerializer.Serialize(networkStream, newHouse);
    }
