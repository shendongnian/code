     System.Text.Encoding Encoder = System.Text.ASCIIEncoding.Default;
     Byte[] buffer = new byte[]{(byte)149};
     string bullet = Encoding.GetEncoding(1252).GetString(buffer);
    //why are you adding the "." bullet back with BODY = BODY + "." ?
    
    Create a StringBuilder and use the Append Method()
    StringBuilder messageBuilder = new StringBuilder(); //add a capacity if you know the size you want like this for example StringBuilder messageBuilder = new StringBuilder(200); 
    messageBuilder.Append("\t\u2022\t"); 
    messageBuilder.Append("Text1\r\n");
    
    follow the pattern with what you need.
    Thanks
