    var cbox = new DataGridViewCheckBoxColumn // Modify column type
    {
        AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
        DataPropertyName = dgv.Columns["ColumnWantToChange"].Name, 
        HeaderText = "SOME HEADER NAME"
    };
    dgv.Columns.Add(cbox); // Add new 
    var r = dgv.Columns.OfType<DataGridViewTextBoxColumn>().Where(x => x.Name == "ColumnWantToChange").FirstOrDefault();
    dgv.Columns.Remove(r); // Remove the original column
