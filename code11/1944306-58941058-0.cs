        var encoder = new UTF8Encoding();
        byte[] keyBytes = encoder.GetBytes(key);
        var newlinemsg = action + "\n" + msg;
        byte[] messageBytes = encoder.GetBytes(newlinemsg);
        byte[] hashBytes = new HMACSHA512(keyBytes).ComputeHash(messageBytes);
        var hexString = ToHexString(hashBytes);
        var base64 = Convert.ToBase64String(encoder.GetBytes(hexString));
