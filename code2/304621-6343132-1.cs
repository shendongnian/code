    public bool CloseCOMPort()
    {
        bool isClosed = false;
        try
        {
            if (oSerialPortMisc != null && oSerialPortMisc.IsOpen)
            {
                oSerialPortMisc.Close();
                isClosed=true;
            }
            else
            {
                isClosed = false;
            }
        }
        catch (Exception exp)
        {
        }
        return isClosed;
    }
