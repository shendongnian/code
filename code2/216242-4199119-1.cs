    private static void DumpNewData(FileStream fs, int bytesToRead)
    {
        byte[] bytesRead = new byte[bytesToRead];
        fs.Read(bytesRead, 0, bytesToRead);
        string s = System.Text.ASCIIEncoding.ASCII.GetString(bytesRead);
        Console.Write(s);
    }
