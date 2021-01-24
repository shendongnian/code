    try
    {
        DataReader reader1 = new DataReader(socket.InputStream);
        reader1.InputStreamOptions = InputStreamOptions.Partial;
        uint numFileBytes = await reader1.LoadAsync(2048);
        byte[] byArray = new byte[numFileBytes];
        reader1.ReadBytes(byArray);
        string test = BitConverter.ToString(byArray);
        Debug.WriteLine("Conversion : " + test);
    }
    catch (Exception exception)
    {
        Debug.WriteLine("ERROR LECTURE : " + exception.Message);
    }
