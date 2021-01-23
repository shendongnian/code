    public bool SomethingEnabled
    {
       if (IsInvalid) return false;
       return IsInReadyState && IsInOtherState;
    }
    public bool IsInvalid
    {
       return !condition1;
    }
    public bool IsInReadyState
    {
       return condition3 || !condition4;
    }
    public bool IsInOtherState
    {
       return condition2;
    }
