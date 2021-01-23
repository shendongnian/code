    public dlgDbConnProps ( Form Owner )
    {
        // TODO: Complete member initialization
        InitializeComponent ( );
    
        owner = Owner;
    }
    
    private void cbo_ProviderLst_SelectedIndexChanged ( object sender, EventArgs e )
    {
        owner.Provider = cboLst.Text;
    }
