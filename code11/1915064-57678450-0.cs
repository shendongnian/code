    // Interface Definition
    [OperationContract(IsOneWay = false)]
    [FaultContractAttribute(typeof(IpcToTrayFault))]
    void OpenCallback(IpcCallbackDest callbackDest);
    // In Service
    //
    public static IIpcAppToServiceBack CallbackApp { get; private set; } = null;
    public static IIpcAppToServiceBack CallbackTray { get; private set; } = null;
    
    public void OpenCallback(IpcCallbackDest callbackDest)
    {
    	switch (callbackDest)
    	{
    		case IpcCallbackDest.App:
    			IpcAppToService.CallbackApp = OperationContext.Current.GetCallbackChannel<IIpcAppToServiceBack>();
    			break;
    		case IpcCallbackDest.Tray:
    			IpcAppToService.CallbackTray = OperationContext.Current.GetCallbackChannel<IIpcAppToServiceBack>();
    			break;
    		default:
    			break;
    	}
    }
