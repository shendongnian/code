    string fileName = @"C:\Users\Andy\Desktop\tinytest.png";
    byte[] file = File.ReadAllBytes(fileName);
    byte[] footer = Encoding.ASCII.GetBytes(footerString);
    byte[] lengthBytes = BitConverter.GetBytes(footer.Length);
    byte[] fileAndFooter = new byte[file.Length + footer.Length+lengthBytes.Length];
    System.Buffer.BlockCopy(lengthBytes, 0, filteAndFooter, 0, lengthBytes.Length);
    System.Buffer.BlockCopy(footer, 0, fileAndFooter, lengthBytes.Length, footer.Length);
    System.Buffer.BlockCopy(file, 0, fileAndFooter, footer.Length+lengthBytes.Length, file.Length);
