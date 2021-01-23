    string data = "This is a test.";
    byte[] key = { 1, 2, 3, 4, 5 };
    
    // encrypt
    byte[] enc = RC4.Encrypt(key, Encoding.UTF8.GetBytes(data));
    
    // turn into base64 for convenient transport as form data
    string base64 = Convert.ToBase64String(enc);
    
    Console.WriteLine(base64);
    
    // turn back into byte array
    byte[] code = Convert.FromBase64String(base64);
    
    // decrypt
    string dec = Encoding.UTF8.GetString(RC4.Decrypt(key, code));
    
    Console.WriteLine(dec);
