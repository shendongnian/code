    var sunIsBurning = true;
    while (sunIsBurning) {
        var bytes = new Byte[16];
        int received = socket.Receive(bytes);
        if (received > 0)
            Console.Out.WriteLine("Got {0} bytes. START:{1}END;", received, Encoding.UTF8.GetString(bytes));
    }
