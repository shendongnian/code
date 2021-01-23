    byte[] GetPartialPackage(string filePath, long offset, int count)
    {
        using (var reader = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            reader.Seek(offset, SeekOrigin.Begin);
            int avaliableCount = Math.Min(count, (int)(reader.Length - offset));
            byte[] tempData = new byte[avaliableCount];
            int num = reader.Read(tempData, 0, avaliableCount);
            return tempData;
        }
    }
