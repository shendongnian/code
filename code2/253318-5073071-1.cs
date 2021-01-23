    // Get the string from the user
    string s=Console.ReadLine();
    // Convert to a byte array
    byte[] sBytes=Encoding.ASCII.GetBytes(s);
    // Display the bytes (optional)
    StringBuilder hexString=new StringBuilder(sBytes.Length*3);
    foreach (byte b in sBytes)     
    {
      // Separate hex pairs with a space
      if (hexString.Length>0)
        hexString.Append(' ');
      // Append next hex pair (i.e., formatted byte)
      hexString.AppendFormat("{0:x2}",b);
    }
    Console.WriteLine(hexString);
