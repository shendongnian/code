    void Send(Stream stream)
    {
        BinaryFormatter binaryFmt = new BinaryFormatter();
        House h = new House()
        {
            Street = "Mill Lane",
            PostalCode = "LO1 BT5",
            HouseNumber = 11,
            HouseID = 1,
            City = "London"
        };
        binaryFmt.Serialize(stream, h);
    }
