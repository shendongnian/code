    string inputText = "This is some text.";
    byte [] bytesToEncode = Encoding.Unicode.GetBytes (inputText);
 
    string encodedText = Convert.ToBase64String (bytesToEncode);
    
    byte [] decodedBytes = Convert.FromBase64String (encodedText);
    string decodedText = Encoding.Unicode.GetString (decodedBytes);
           
