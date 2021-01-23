    internal string _message;
 
    public Exception(string message)
    {
        this.Init();
        this._message = message;
    }
    
    
    private void Init()
    {
        this._message = null;
        this._stackTrace = null;
        this._dynamicMethods = null;
        this.HResult = -2146233088;
        this._xcode = -532462766;
        this._xptrs = IntPtr.Zero;
        this._watsonBuckets = null;
        this._ipForWatsonBuckets = UIntPtr.Zero;
        this._safeSerializationManager = new SafeSerializationManager();
    }
    public virtual string Message
    {
        [SecuritySafeCritical]
        get
        {
            if (this._message != null)
            {
                return this._message;
            }
            if (this._className == null)
            {
                this._className = this.GetClassName();
            }
            return Environment.GetRuntimeResourceString("Exception_WasThrown", new object[] { this._className });
        }
    }
     
