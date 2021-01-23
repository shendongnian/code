    public bool CloseCOMPort()
        {
            try
            {
                bool isClosed = false;
                if (oSerialPortMisc != null && oSerialPortMisc.IsOpen)
                {
                    oSerialPortMisc.Close();
                    isClosed=true;
    
                }
                else
                {
                    isClosed = false;
    
                }
                return isClosed;
            }
            catch (Exception exp)
            {
    		return false;
            }
        }
