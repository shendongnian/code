    private void InitializeHooks()
    {
        foreach(var control in ControlsTree)
        {
           var button = control as Button;
           if (button != null)
           {
              button.Click += OnClicked;
              continue;
           }
           
           var checkBox = control as CheckBox;
           if (checkBox != null)
           {
              checkBox.EnabledChanged += OnEnabledChanged;
           }       
        }
    }
    
    // Button click handler
    private void OnClicked(object sender, EventArgs eventArgs)
    {
       txtOutput.Text = String.Format(
                                    CultureInfo.CurrentCulture,
                                    "{Control Type: {0}, Name: {1}, Event: Click",
                                    sender.GetType().Name,
                                    sender.Id);
    }
    // Checkbox Enabled state changed handler
    private void OnEnabledChanged(object sender, EventArgs eventArgs)
    {
         txtOutput.Text = String.Format(
                                    CultureInfo.CurrentCulture,
                                    "{Control Type: {0}, Name: {1}, Event: EnabledChanged",
                                    sender.GetType().Name,
                                    sender.Id);
    }
