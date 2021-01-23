    [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
    public override string ToString()
    {
        return this.ToString(true);
    }
    
    private string ToString(bool needFileLineInfo)
    {
        string className;
        string message = this.Message;
        if ((message == null) || (message.Length <= 0))
        {
            className = this.GetClassName();
        }
        else
        {
            className = this.GetClassName() + ": " + message;
        }
        if (this._innerException != null)
        {
            className = className + " ---> " + this._innerException.ToString(needFileLineInfo) + Environment.NewLine + "   " + Environment.GetRuntimeResourceString("Exception_EndOfInnerExceptionStack");
        }
        string stackTrace = this.GetStackTrace(needFileLineInfo);
        if (stackTrace != null)
        {
            className = className + Environment.NewLine + stackTrace;
        }
        return className;
    }
    
     
