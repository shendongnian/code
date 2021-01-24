    //Get a flipped version of what the final bytes should be
    var endingBytes = Encoding.UTF8.GetBytes("--\r\n").Reverse().ToArray();
    var requiresRepair = false;
    
    var last4Bytes = new byte[4];
    //Check if the final bites line up
    for (int i = 0; i < 4; i++)
    {
        last4Bytes[i] = bytes[bytes.Length - (i + 1)];
    }
    
    var lastBytesAsString = System.Text.Encoding.UTF8.GetString(last4Bytes);
    Logger.LogInformation($"MIDDLEWARE: Last 4 bytes {lastBytesAsString}");
    
    //Check if the final bites line up
    for (int i = 0; i < 4; i++)
    {
        if (bytes[bytes.Length - (i + 1)] != endingBytes[i])
        {
            requiresRepair = true;
            break;
        }
    }
