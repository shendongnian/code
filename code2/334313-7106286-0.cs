    System.Text.Encoding iso_8859_1 = System.Text.Encoding.GetEncoding("iso-8859-1");
    port.Encoding = iso_8859_1;
    
    string s = port.ReadLine();
    
    byte[] theBytes = iso_8859_1.GetBytes(s);
