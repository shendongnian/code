    /// <summary>
    /// Overrides the OnLoad event moves the cursor to the appropriate control.
    /// </summary>
    /// <param name="e"></param>
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
    
        int currentTabIndex = 1;
        WebControl postBackCtrl = (WebControl)GetControlThatCausedPostBack(Page);    
        foreach (WebControl ctrl in Panel1.Controls.OfType<WebControl>())
        {
            ctrl.TabIndex = (short)currentTabIndex;
            if (postBackCtrl != null)
            {
                if (ctrl.TabIndex == postBackCtrl.TabIndex + 1)
                    ctrl.Focus();
            }
            currentTabIndex++;
        }                                        
    }
    /// <summary>
    /// Retrieves the control that caused the postback.
    /// </summary>
    /// <param name="page"></param>
    /// <returns></returns>
    private Control GetControlThatCausedPostBack(Page page)
    {
        //initialize a control and set it to null
        Control ctrl = null;
    
        //get the event target name and find the control
        string ctrlName = Page.Request.Params.Get("__EVENTTARGET");
        if (!String.IsNullOrEmpty(ctrlName))
            ctrl = page.FindControl(ctrlName);
    
        //return the control to the calling method
        return ctrl;
    }
