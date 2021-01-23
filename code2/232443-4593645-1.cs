    protected void Page_Load(object sender, EventArgs e)
    {
        MasterPageObject m = (MasterPageObject)base.Master;
        m.AfterSave += onMasterSave;
    }
    private void onMasterSave(object sender, EventArgs e)
    {
        // Your processing here
    }
