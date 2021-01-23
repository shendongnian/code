	public TablessControl()
	{
		bool designMode = (LicenseManager.UsageMode == LicenseUsageMode.Designtime);
		if (!designMode) Multiline = true;		
	}
