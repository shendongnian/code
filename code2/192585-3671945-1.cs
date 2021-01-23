    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (chkSomeCheckbox_0.Checked)
            {
                txtSomeTextbox.Visible = true;
            }
        }
    }
