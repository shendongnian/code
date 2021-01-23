    private void BindControls()
    {
        // Bind the values to from the controls in the group to the properties class
        // When the line below is commented out the control behaves normally
        this.checkedGroupBox1.DataBindings.Add("Checked", m_TP, "GroupChecked", false, DataSourceUpdateMode.OnPropertyChanged);
        this.numericUpDown1.DataBindings.Add("Value", m_TP, "SomeNumber", false, DataSourceUpdateMode.OnPropertyChanged);
        this.textBox1.DataBindings.Add("Text", m_TP, "SomeText", false, DataSourceUpdateMode.OnPropertyChanged);
        this.checkBox1.DataBindings.Add("Checked", m_TP, "BoxChecked", false, DataSourceUpdateMode.OnPropertyChanged);
        // Bind the values of the properties to the lables
        this.label4.DataBindings.Add("Text", m_TP, "GroupChecked");
        this.label5.DataBindings.Add("Text", m_TP, "SomeNumber");
        this.label6.DataBindings.Add("Text", m_TP, "SomeText");
        this.label8.DataBindings.Add("Text", m_TP, "BoxChecked");
    }
