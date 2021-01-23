    public MyForm()
    {
        InitializeComponent(); // this is the call to the auto-generated code
        
        // Here you could add you own code:
        foreach (Control control in controls)
        {
            this.Controls.Add(control); // this is how to add a control to the form.
        }
    }
