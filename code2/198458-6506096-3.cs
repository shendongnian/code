    //form init, auto-generated code (this is the case described)
    private void InitializeComponent()
    {
        //....
        this.AcceptButton = btnOk;
        this.btnOk.DialogResult = DialogResult.OK;
        //....
    }
    //event handlers
    private void btnOK_Click(object sender, EventArgs e)
    {
    	if (!Validate())
    		this.DialogResult = DialogResult.None;
    }
    
    private void Form_FormClosing(object sender, FormClosingEventArgs e)
    {
    	if (this.DialogResult == DialogResult.None)
    		e.Cancel = true;
    }
