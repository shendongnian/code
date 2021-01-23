    // Inside COMManager
    public event DataReceivedEventHandler DataReceived;
    
    void serialPort_DataReceived(...)
    {
        // do whatever
        if (DataReceived != null)
        {
            DataReceived(this, eventArgs);
        }
    }
