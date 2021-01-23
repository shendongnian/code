    StreamReader stream = null;
    char[] buffer = new char[chunksize];
    
    try
    {
        try
        {
            stream = new StreamReader(file.OpenRead(), Encoding);
        }
        catch (Exception ex)
        {
            throw ExceptionMapper.Map(ex, file.FullName);
        }
        
        int readCount;
        Func<bool> peek = () =>
        {
            try
            {
                return stream.Peek() >= 0;
            }
            catch (Exception ex)
            {
                throw ExceptionMapper.Map(ex, file.FullName);
            }
        };
        
        while (peek())
        {
            try
            {
                readCount = stream.Read(buffer, 0, chunksize);
            }
            catch (Exception ex)
            {
                throw ExceptionMapper.Map(ex, file.FullName);
            }
    
            yield return new string(buffer, 0, readCount);
        }
    }
    finally
    {
        if (stream != null)
        {
            stream.Dispose();
            stream = null;
        }
    }
