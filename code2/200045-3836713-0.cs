    public void OnInit(object sender, EventArgs e)
    {
        GatherForms();
        CreateWizardForm(); // creates a wizard and adds controls it will need
    }
    
    private void Checkbox_Checked(object sender, EventArgs e)
    {
        var checkBox = (CheckBox)sender;
        // append checkBox.SelectedValue to session state object of checkboxes
    }
    
    protected override void OnPreRender(object sender, EventArgs e)
    {
        if (/* Session checkboxes contain values */)
        {
            this.WizardForm.Visible = true;
            this.CheckboxList.Visible = false;
        }
    }
