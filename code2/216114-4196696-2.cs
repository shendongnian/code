    byte[] byteArray = new byte[] { 1, 2, 3, 253, 254, 255 };
    // hexString will be "010203FDFEFF"
    string hexString = string.Concat(byteArray.Select(b => b.ToString("X2")));
    // b64String will be "AQID/f7/"
    string b64String = Convert.ToBase64String(byteArray);
