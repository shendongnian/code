    private void CopyPartial(string sourceName, byte syncByte, string destName)
    {
        using (var input = File.OpenRead(sourceName))
        using (var reader = new BinaryReader(input))
        using (var output = File.Create(destName))
        {
            var start = 0;
            // seek to sync byte
            while (reader.ReadByte() != syncByte)
            {
                start++;
            }
            var buffer = new byte[4096]; // 4k page - adjust as you see fit
            do
            {
                var actual = reader.Read(buffer, 0, buffer.Length);
                output.Write(buffer, 0, actual);
            } while (reader.PeekChar() >= 0);
        }
    }
