    protected void Page_Load(object sender, EventArgs e)
    {
        if (ViewState["buttons"] != null)
            CreateButtons();
    }
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        ViewState["buttons"] = true;
        CreateButtons();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ViewState["buttons"] != null)
        {
            // Save the button information.
            foreach (Control ctl in phButtons.Controls)
            {
                string x;
                if (ctl is TextBox)
                    x = (ctl as TextBox).Text;
            }
        }
    }
    private void CreateButtons()
    {
        for (int iLoop = 0; iLoop < 5; iLoop++)
        {
            phButtons.Controls.Add(new TextBox() { ID = "txt" + iLoop });
        }
    }
