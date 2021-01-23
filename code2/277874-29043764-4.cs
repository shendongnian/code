    public bool HostedDesignMode
    {
        get
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return true;
            else
                return false;
        }
    }
