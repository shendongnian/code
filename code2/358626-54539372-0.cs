    /// <summary>
    /// Fixed according to http://msdn.microsoft.com/en-us/library/system.runtime.interopservices.safehandle.isinvalid(v=vs.80).aspx
    /// </summary>
    public override bool IsInvalid
    {
        get { return IsClosed || handle == IntPtr.Zero; }
    }
