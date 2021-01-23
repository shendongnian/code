    protected void addTrigger_PreRender(object sender, EventArgs e)
    {
        if (sender is ImageButton)
        {
            ImageButton imgBtn = (ImageButton)sender;
            ScriptManager ScriptMgr = (ScriptManager)this.FindControl("ScriptManager1");
            ScriptMgr.RegisterPostBackControl(ImgBtn);
        }
    }
