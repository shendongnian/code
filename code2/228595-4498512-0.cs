     protected bool IsInDesignMode
     {
        get
        {
                return DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        }
     }
