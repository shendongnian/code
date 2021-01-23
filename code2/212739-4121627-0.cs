    ReadDataGridViewComboBoxColumn.ValueType = typeof(ReadAccess);
    ReadDataGridViewComboBoxColumn.ValueMember = "Value";
    ReadDataGridViewComboBoxColumn.DisplayMember = "Display";
    ReadDataGridViewComboBoxColumn.DataSource = new ReadAccess[]
        { ReadAccess.None, ReadAccess.Allowed }
        .Select(
            (ReadAccess value) => new { Display=value.ToString(), Value=(int)value }
        )
        .ToList();
