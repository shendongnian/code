    public void Page_Load(object sender, EventArgs e)
    {
        string typeName = custommodule.ModuleInternetFile;
        inpagelink.HRef = "#" + custommodule.ModuleName.Replace(" ", "").Replace("/", "");
        modtitle.InnerText = custommodule.ModuleName;
        Type child = Type.GetType(typeName);
        UserControl ctl = (UserControl)Page.LoadControl(child, null);
        if (ctl != null)
        {
            this.modsection.Controls.Add(ctl);
        }
        // Now let the inheritors execute their code
        OnPageLoad();
    }
