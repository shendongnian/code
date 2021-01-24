        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Update the label automatically from the setting
            label2.DataBindings.Add("Text", Properties.Settings.Default, "CounterText", true, 
                                           DataSourceUpdateMode.OnPropertyChanged);
        }
