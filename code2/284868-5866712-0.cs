    DataColumn fNameColumn8 = new DataColumn();
    fNameColumn8.DataType = System.Type.GetType("System.String");
    m_dataTable.Columns.Add(fNameColumn8);
    
    ColumnStyle myStyleColumn8 = new ColumnStyle(7);
    myStyleColumn8.TextAlign = ContentAlignment.TopRight;
    
    DataGridTableStyle dataGridTableStyle = new DataGridTableStyle();
    dataGridTableStyle.MappingName = MAPPINGNAME;
    dataGridTableStyle.GridColumnStyles.Add(myStyleColumn8);
    
    this.dataGrid.TableStyles.Add(dataGridTableStyle);
