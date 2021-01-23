    // Set initial values
    radioButton1.Checked = model.Checked;
    radioButton2.Checked = model.Checked;
    // Change on event
    radioButton1.CheckedChanged += delegate { model.rb1Checked = radioButton1.Checked; };
    radioButton2.CheckedChanged += delegate { model.rb2Checked = radioButton2.Checked; };
    // These stay the same
    checkBox1.DataBindings.Add(new Binding("Enabled", bindingSource, "cb1Enabled", true, DataSourceUpdateMode.OnPropertyChanged));
    checkBox2.DataBindings.Add(new Binding("Enabled", bindingSource, "cb2Enabled", true, DataSourceUpdateMode.OnPropertyChanged));
