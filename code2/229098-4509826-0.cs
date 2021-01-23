    public bool ByteArrayToFile(string FileName, byte[] ByteArray)
    {
        try
        {
            System.IO.FileStream vFileStream = new System.IO.FileStream(FileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            vFileStream.Write(vByteArray, 0, vByteArray.Length);
    
            vFileStream.Close();
    
            return true;
        }
        catch (Exception pException)
        {
            Console.WriteLine("Exception caught in process: {0}", pException.ToString());
        }
    
        return false;
    }
