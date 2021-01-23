    protected AutoResetEvent deviceOpenedEvent = new AutoResetEvent(false);
    protected AutoResetEvent deviceLockedEvent = new AutoResetEvent(false);
    bool TestDevice() {
        // Presuming this invokes DeviceOpened when it's finished
        OpenDevice();
        // Do some unrelated parallel stuff here ... then
        deviceOpenedEvent.WaitOne();
        LockDevice();
        deviceLockedEvent.WaitOne();
    }
    void DeviceOpenedEvent() {
        deviceOpenedEvent.Set();                           
    }
