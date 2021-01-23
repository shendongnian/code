    private void button2_Click(object sender, RoutedEventArgs e)
    {
        MemoryStream ms = new MemoryStream();
        byte [] original = BitConverter.GetBytes((int)2224); // 176, 8, 0, 0
        ms.Write(original, 0, original.Length);
        ms.Seek(0, SeekOrigin.Begin);
        byte [] data = new byte[4];
        int count = ms.Read(data, 0, 4); // count is 4, data is 176, 8, 0, 0
        int fileSize = BitConverter.ToInt32(data, 0); // is 2224
        return;
    }
