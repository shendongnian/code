    private bool bIsReceivingHeartbeat;
    public bool IsReceivingHeartbeat
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        get { return bIsReceivingHeartbeat; }
        [MethodImpl(MethodImplOptions.Synchronized)]
        set { bIsReceivingHeartbeat = value; }
    }
