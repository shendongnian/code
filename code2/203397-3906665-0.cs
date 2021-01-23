    // This line is picked up from designer file for reference
      DataGridViewComboBoxColumn CustomerColumn; 
    
      DataTable _customersDataTable = GetCustomers();
    
      CustomerColumn.DataSource = _customersDataTable;
      CustomerColumn.DisplayMember = Customer_Name;
      CustomerColumn.ValueMember = ID;
    
      var graphics = CreateGraphics();
    
      // Set width of the drop down list based on the largest item in the list
      CustomerColumn.DropDownWidth = (from width in
                             (from DataRow item in _customersDataTable.Rows
                              select Convert.ToInt32(graphics.MeasureString(item[Customer_Name].ToString(), Font).Width))
                           select width).Max();
