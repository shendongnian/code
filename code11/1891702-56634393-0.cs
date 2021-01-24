    streamWriter = new StreamWriter(netStream);
    // Get New Trip
    if (netStream.CanWrite) {
        Byte[] PCMSCommandBuffer = Encoding.ASCII.GetBytes("PCMSNewTrip");
        //netStream.Write(PCMSCommandBuffer, 0 , PCMSCommandBuffer.Length);
        streamWriter.WriteLine("PCMSNewTrip");
        //netStream.Flush();
        streamWriter.Flush();
        Console.WriteLine(PCMSCommandBuffer.Length + " PCMSNewTrip");
        Thread.Sleep(1000);
    } else {
        Console.WriteLine("Cannot write to EW-APP1.");
    }
