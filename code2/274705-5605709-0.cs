    //This is a class property of the form itself. 
    public bool IsValid { get; set; }
    private void ValidateForm()
    {
        Action<Control.ControlCollection> func = null;
    
        func = (controls) =>
        {
            foreach (Control control in controls)
                if (control is TextBox)
                    if (String.IsNullOrEmpty(control.Text))
                        this.IsValid = false;
                else
                    func(control.Controls);
        };
    
        func(Controls);
    }
