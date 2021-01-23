    static bool Read(FileStream fs, byte[] data, long position)
    {
        fs.Seek(position, SeekOrigin.Begin);
            
        if (fs.ReadByte() == 0)
        {
            // Block of data not finished writing
            return false;
        }
        fs.Read(data, 0, data.Length);
        return true;
    }
    static bool Write(FileStream fs, byte[] data, long position)
    {
        try
        {
            fs.Lock(position, data.Length + 1);
            fs.Seek(position, SeekOrigin.Begin);
            fs.WriteByte(0);
            fs.Write(data, 0, data.Length);
            fs.Seek(position, SeekOrigin.Begin);
            fs.WriteByte(1);
            fs.Unlock(position, data.Length + 1);
            return true;
        }
        catch (IOException)
        {
            return false;
        }
    }
    static bool Append(FileStream fs, byte[] data)
    {
        return Write(fs, data, fs.Length);
    }
