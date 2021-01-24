    public async Task<string> ImportLines(string filename)
    {
        try
        {
            StorageFile importFile = await ApplicationData.Current.LocalFolder.GetFileAsync(filename);
            var buffer = await FileIO.ReadBufferAsync(importFile);
            using (var dataReader = Windows.Storage.Streams.DataReader.FromBuffer(buffer))
            {
                return dataReader.ReadString(buffer.Length);
            }
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
