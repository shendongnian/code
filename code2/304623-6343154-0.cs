    public bool CloseCOMPort()
    {
        try
        {
            if (oSerialPortMisc != null && oSerialPortMisc.IsOpen)
            {
                oSerialPortMisc.Close();
                return true;
            }
        }
        catch (Exception exp)
        {
            // Add some logging of the exception here
        }
        finally
        {
            return false;
        }
    }
