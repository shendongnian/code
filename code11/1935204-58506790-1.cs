    PipeSecurity CreateSystemIOPipeSecurity()
    {
        PipeSecurity pipeSecurity = new PipeSecurity();
         var id = new SecurityIdentifier(WellKnownSidType.AuthenticatedUserSid, null);
        // Allow Everyone read and write access to the pipe. 
        pipeSecurity.SetAccessRule(new PipeAccessRule(id, PipeAccessRights.ReadWrite, AccessControlType.Allow));
        return pipeSecurity;
    }
    public MainWindow()
    {
        InitializeComponent();
        PipeSecurity ps = CreateSystemIOPipeSecurity();
        pipeServer = new NamedPipeServerStream(
            "TestPipe", 
            PipeDirection.InOut,
            1,
            PipeTransmissionMode.Byte,
            PipeOptions.Asynchronous,
            512,
            512,
            ps,
            System.IO.HandleInheritability.Inheritable);
