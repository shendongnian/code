    Dictionary<string, string>test = new Dictionary<string, string>();
        test.Add("Space", " ");
        test.Add("Comma", ",");
        test.Add("New Line", Environment.NewLine);
        comboBox1.DataSource = new BindingSource(test, null); //Assign the items to combobox
        comboBox1.DisplayMember = "Value";
        comboBox1.ValueMember = "Key";
