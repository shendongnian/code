    {
        var reader = new BinaryReader(((HttpWebResponse)request.GetResponse()).GetResponseStream());
        try
        {
          // do something with reader
        }
        finally
        {
            if (reader != null)
                ((IDisposable)reader).Dispose();
        }
    }
