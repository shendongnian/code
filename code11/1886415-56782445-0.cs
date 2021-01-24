    // Decode the whole string to make sure it is a valid Base64
    byte[] data = Convert.FromBase64String(base64String);
    // Just for readability store it as HEX
    // You might want to store only the file header (eg, 64 bytes)
    string hex = BitConverter.ToString(data);
    
    if (hex.StartsWith("49-44-33"))
    {
      Console.WriteLine("mp3");
    }
    else if (hex.StartsWith("66-4C-61-43"))
    {
      Console.WriteLine("flac");
    }
    else {
      Console.WriteLine("unknown:" + hex);
    }
