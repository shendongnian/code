    public override int PreServLogin()
    {
        if (GetBoolSetting("NeedReg"))
        {
            Log("Registering first... Please wait");
            return Registration();
        }
        return base.PreServLogin();
    }
