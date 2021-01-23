    public string Name
    {
        get { return GetProperty(MethodBase.GetCurrentMethod()); }
        set
        {
            SetProperty(MethodBase.GetCurrentMethod(), value);
        }
    }
    private string GetProperty(MethodBase method)
    {
        return _dr[method.Name.Substring(4)].ToString();
    }
    private void SetProperty(MethodBase method, string value)
    {
        string methodName = method.Name.Substring(4);
        VerifyAccess(methodName , this.GetType().Name);
        _dr[methodName] = value;
    }
