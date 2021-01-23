    List<MyObject> usepurposeBindingSource { get; set; }
    private void FillUpData()
    {
        // Simulating an External Data
        if (usepurposeBindingSource == null || usepurposeBindingSource.Count == 0)
        {
            this.usepurposeBindingSource = new List<MyObject>();
            this.usepurposeBindingSource.Add(new MyObject() { Name = "A", ID = 1 });
            this.usepurposeBindingSource.Add(new MyObject() { Name = "B", ID = 2 });
            this.usepurposeBindingSource.Add(new MyObject() { Name = "C", ID = 3 });
        }
    }
    private void FillUpCombo()
    {
        FillUpData();
        // what you have from design
        // comment out the first line
        //this.usepurposeComboBox.DataSource = this.usepurposeBindingSource;
        this.usepurposeComboBox.DisplayMember = "Name";
        this.usepurposeComboBox.FormattingEnabled = true;
        this.usepurposeComboBox.Location = new System.Drawing.Point(277, 53);
        this.usepurposeComboBox.Name = "usepurposeComboBox";
        this.usepurposeComboBox.Size = new System.Drawing.Size(218, 21);
        this.usepurposeComboBox.TabIndex = 4;
        this.usepurposeComboBox.ValueMember = "id";
        // to do in code:
        this.usepurposeBindingSource.Insert(0, new MyObject() { Name = "Choose One", ID = 0 });
        // bind the data source
        this.usepurposeComboBox.DataSource = this.usepurposeBindingSource;
    }
