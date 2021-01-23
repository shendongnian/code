    private void InitializeHooks()
    {
        foreach(var control in this.Controls)
        {
           var button = control as Button;
           if (button != null)
           {
              button.Click += OnClick;
              continue;
           }
           
           var checkBox = control as CheckBox;
           if (checkBox != null)
           {
              checkBox.CheckedChanged += OnCheckedChanged;
           }       
        }
    }
    
    // Button click handler
    private void OnClick(object sender, EventArgs eventArgs)
    {
       txtOutput.Text = String.Format(
                                    CultureInfo.CurrentCulture,
                                    "{Control Type: {0}, Name: {1}, Event: Click",
                                    sender.GetType().Name,
                                    sender.Id);
    }
    // Checkbox Checked state changed handler
    private void OnCheckedChanged(object sender, EventArgs eventArgs)
    {
         txtOutput.Text = String.Format(
                                    CultureInfo.CurrentCulture,
                                    "{Control Type: {0}, Name: {1}, Event: CheckedChanged",
                                    sender.GetType().Name,
                                    sender.Id);
    }
