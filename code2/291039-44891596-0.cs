    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            SetFocusAfterPostBack();
        }
    }
	public static void SetFocusAfterPostBack()
	{
		var page = HttpContext.Current.Handler as Page;
		if (page == null)
		{
			return;
		}
		var postBackCtl = page.FindControl(HttpContext.Current.Request.Form["__EVENTTARGET"]) as WebControl;
		if (postBackCtl == null || postBackCtl.TabIndex == 0)
		{
			return;
		}
		var ctl = GetCtlByTabIndex(page, postBackCtl.TabIndex + 1);
		if (ctl != null)
		{
			ctl.Focus();
		}
	}
	private static WebControl GetCtlByTabIndex(Control ParentCtl, int TabIndex)
	{
		foreach (Control ctl in ParentCtl.Controls)
		{
			var webCtl = ctl as WebControl;
			if (webCtl != null)
			{
				if (webCtl.TabIndex == TabIndex)
				{
					return webCtl;
				}
			}
			var retCtl = GetCtlByTabIndex(ctl, TabIndex);
			if (retCtl != null)
			{
				return retCtl;
			}
		}
		return null;
	}
