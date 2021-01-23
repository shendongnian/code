    public bool CloseCOMPort()
    {
        bool isClosed = false;
        try
        {
            if (oSerialPortMisc != null && oSerialPortMisc.IsOpen)
            {
                oSerialPortMisc.Close();
                isClosed = true;
            }
        }
        catch (Exception exp)
        {
            // Add some logging of the exception here
        }
        finally
        {
            return isClosed;
        }
    }
