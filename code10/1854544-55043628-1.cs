    if (port.IsOpen)
    {
        byte[] data = new byte[1024];
        int bytesRead = port.Read(data, 0, data.Length);
        _tagBuffer += Encoding.ASCII.GetString(data, 0, bytesRead);
    
        if (_tagBuffer.Length >= 8)
        {        
            idTag = tagBuffer.substring(0, 8);
            tagBuffer = tagBuffer.substring(8); // might be 9
            
            OnTagReceived();
        }
    }
