    private const int DEF_BUFFER = 100;
    private const int DEF_INTERVAL = 10;
    public StreamCopyOperation(Stream source, Stream target)
    {
       //Initialize values
       this.BufferSize = DEF_BUFFER;
       this.UpdateInterval = DEF_INTERVAL;
    } 
    public int BufferSize { get; set;} // or use a private member inside, if needed
    public int UpdateInterval { get; set;} // or use a private member inside, if needed
