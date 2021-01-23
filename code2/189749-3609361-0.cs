    public readonly object lockThis = new object();
    private readonly ManualResetEvent resetHandle = new ManualResetEvent(false);
    private void SimulnProgress()
    {
        resetHandle.WaitOne();
       
        lock (lockThis)
        {
            UIControlHandler.Instance.ShowSimulationProgress();
        }
    }
    
    private void XmlResetFn()
    {
        lock (lockThis)
        {
            DataStoreSingleTon.Instance.GetFPBConfigurationInstance().ResetXmlAfterCollision();
        }
    
        resetHandle.Set();
    }
