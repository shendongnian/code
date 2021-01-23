    Binding SelectedValueBinding = new Binding("SelectedValue", repository, "RepositoryValue", true, DataSourceUpdateMode.OnPropertyChanged);
    SelectedValueBinding.Format += new ConvertEventHandler(SelectedValueBinding_Format);
    myComboBox.DataBindings.Add(SelectedValueBinding);
    void SelectedValueBinding_Format(object sender, ConvertEventArgs e)
    {
            // if e.Value is Invalid
            // myComboBox.SelectedValue = "Default Value";
    }
