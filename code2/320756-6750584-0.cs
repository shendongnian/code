    // your byte array for the message
    byte[] TheMessage = ...;
    // a string representation of your message (the character 0x01... 0x32 are NOT altered)
    string MessageString = Encoding.ASCII.GetString(TheMessage);
    // replace whatever you want...
    MessageString = MessageString.Replace (" ", "x").Replace ( "\n", " " )...
    // the replaced message back as byte array
    byte[] TheReplacedMessage= Encoding.ASCII.GetBytes(MessageString.ToCharArray());
