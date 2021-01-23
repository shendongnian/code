    public DataGridViewComboBoxColumn CreateComboBoxColumn(string strSQLSelect, string strColName, string strDisplay, string strValue) 
    { 
    // Returns the DataGridViewComboBoxColumn to be inserted 
    DataGridViewComboBoxColumn colComboColumn = new DataGridViewComboBoxColumn(); 
    DataTable dtbElements = new DataTable(); 
    MySqlDataAdapter dbaElements = new MySqlDataAdapter(strSQLSelect, conn); 
    // Set some parameters for the ComboBoxColumn 
    colComboColumn.Name = strColName; 
    colComboColumn.DisplayMember = strDisplay; 
    colComboColumn.ValueMember = strValue; 
    // Add the Elements 
    dbaElements.Fill(dtbElements); 
    colComboColumn.DataSource = dtbElements; 
    // Return the column 
    return colComboColumn; 
    } 
