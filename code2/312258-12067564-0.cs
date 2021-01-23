    DataGridTableStyle dgts = new DataGridTableStyle();
    dgts.MappingName = "Cars";
    DataGridTextBoxColumn nameColumn = new DataGridTextBoxColumn();
    nameColumn.MappingName = "Name";
    nameColumn.HeaderText = "Car name";
    nameColumn.Width = 80;
    dgts.GridColumnStyles.Add(nameColumn);
    dataGrid1.TableStyles.Add(dgts);
