    internal void HideController()
    {
        DialogResult dlgResult = MessageBox.Show("Controller will now close.", "Closing...", 
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        if (dlgResult == DialogResult.OK)
        {
            this.Hide();
        }
    }
    static UtilScenario()
    {
        _stkProgramId = ConfigurationManager.AppSettings.Get("stkProgramId");
        if (CheckIfLaunched())
        {
            InitAllFields();
        }
        else
        {
            // a safer cast is recommended
            ((frmUavController)Form.ActiveForm).HideController();
        }
    }
