    void Test()
    {
        Debug.WriteLine("1");
        try
        {
            Debug.WriteLine("2");
            throw new Exception();
            Debug.WriteLine("3");
        }
        catch
        {
            Debug.WriteLine("4");
            throw;
            Debug.WriteLine("5");
        }
        finally
        {
            Debug.WriteLine("6");
        }
        Debug.WriteLine("7");
    }
