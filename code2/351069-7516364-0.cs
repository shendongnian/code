    MyUserControl uc;
    protected void Page_Load()
    {
       if(ViewState["isAdd"]!=null)
        {
           AddControl();
        }
    }
    
    void AddControl()
    {
        uc = Page.LoadControl("MyUserControl.ascx") as MyUserControl;
        divContent.Controls.Add(uc);
    }
    
    protected void ButtonAdd_OnClick(object sender, EventArgs e)
    {
        if(ViewState["isAdd"]==null)
            AddControl();
        ViewState["isAdd"]="yes";
    }
