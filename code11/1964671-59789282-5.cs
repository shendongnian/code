    // packing
    var point = new Point
    {
        X = 1,
        Y = 22
    };
    var genericDtoMessage = new GenericDtoMessage();
    genericDtoMessage.Data = Any.Pack(point);
    
    
    // unpacking
    var unpackedData = genericDtoMessage.Data.Unpack<Point>();
    Console.WriteLine($"X: {unpackedData.X}{Environment.NewLine}Y: {unpackedData.Y}");
    Console.WriteLine($"Press any key to continue...");
    Console.ReadKey();
