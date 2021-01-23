     byte[] binaryString = reader[1];
     // if the original encoding was ASCII
     string x = Encoding.ASCII.GetString(binaryString);
     // if the original encoding was UTF-8
     string y = Encoding.UTF8.GetString(binaryString);
     // if the original encoding was UTF-16
     string z = Encoding.Unicode.GetString(binaryString);
     // etc
