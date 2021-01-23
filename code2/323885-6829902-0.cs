    dataGrid1.TableStyles.Clear();
    DataGridTableStyle tableStyle = new DataGridTableStyle();
    tableStyle.MappingName = t.TableName;
    foreach (DataColumn item in t.Columns)
    {
        DataGridTextBoxColumn tbcName = new DataGridTextBoxColumn();
        tbcName.Width = 100;
        tbcName.MappingName = item.ColumnName;
        tbcName.HeaderText = item.ColumnName;
        tableStyle.GridColumnStyles.Add(tbcName);
     }
     dataGrid1.TableStyles.Add(tableStyle);
