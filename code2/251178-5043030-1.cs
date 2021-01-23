    bool isValid = false;
    protected void Page_Load(object sender, EventArgs e)
    {
    
    }
    
    protected void btnVerify_Click(object sender, EventArgs e)
    {            
        //do some validations
        isValid = chkValid.Checked;
        if (isValid)
            this.Page.ClientScript.RegisterClientScriptBlock(typeof(string), "", "Redirection()", true);
    }
