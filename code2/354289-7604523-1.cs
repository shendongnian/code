    private ParentForm _parentForm;
    
    public AddNewCamper(ParentForm parentForm)
    {
        _parentForm = parentForm;
    }
    
    private void btnNewSubmit_Click_1()
    {
        _parentForm.RefreshCamper(txtNewFirstName.Text);
    }
