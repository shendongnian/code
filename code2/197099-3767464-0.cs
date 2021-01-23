    foreach (NavField field in this.Fields)
    {
        DataGridViewColumn column = new DataGridViewColumn();
        column.HeaderText = field.Caption;
        column.Name = field.FieldNo.ToString();
        column.ValueType = field.GetFieldType();
        column.CellTemplate = new DataGridViewTextBoxCell();
        // added:
        column.DataPropertyName = field.FieldNo.ToString();
        grid.Columns.Add(column);
    }
    grid.DataSource = this.Records;
