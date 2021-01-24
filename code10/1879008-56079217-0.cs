    private readonly Dictionary<string, DataGridView> _tagDBs =
        new Dictionary<string, DataGridView>();
    private void readCSV(string DBname)
    {
        DataGridView tagDBname = new DataGridView();
        // Add the gridview to the dictionary.
        _tagDBs.Add(DBname, tagDBname);
        tagDBname.Name = DBname;
        tagDBname.Location = new System.Drawing.Point(24, 260);
        tagDBname.Size = new System.Drawing.Size(551, 217);
        tagDBname.TabIndex = 6;
        tagDBname.Columns.Add("Column1", "Col1");
        tagDBname.Columns.Add("Column2", "Col2");
        tagDBname.Visible = false;
        comboBoxTag.Items.Add(DBname);
    }
    private void comboBoxTag_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Get the name of the DataGridView which should be visible:
        string selectedTagDB = comboBoxTagDatabases.SelectedItem.ToString();
        if (_tagDBs.TryGetValue(selectedTagDB, out DataGridView tagDatabase)) {
            // Do something with the selected selectedTagDB.
            tagDatabase.Visible = true;
        }
    }
