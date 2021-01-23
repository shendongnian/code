    byte[] GetPartialPackage(string filePath, long offset, int count)
    {
        using (var reader = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            reader.Seek(offset, SeekOrigin.Begin);
            int actualCount = Math.Min(count, reader.Length - offset);
            byte[] tempData = new byte[actualCount];
            reader.Read(tempData, 0, actualCount);        
            return tempdata;
        }
    }
