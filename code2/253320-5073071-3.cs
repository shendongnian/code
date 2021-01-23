    // Get the string from the user
    string s=Console.ReadLine();
    // Convert to a byte array
    byte[] sBytes=s.Split(new char[] {' '})
                   .Select(hexChar => byte.Parse(hexChar,NumberStyles.HexNumber))
                   .ToArray();
    // *** Test code follows ***
    // Display the bytes (optional), to verify that the conversion worked
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
