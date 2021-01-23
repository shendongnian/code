    // You bind the datagridview just as before
    // this dataset should have the idprotocols field which is your foreign key
    // to the protocols table - you will probably want the to be hidden.
    bindingSource = new BindingSource(); 
    bindingSource.DataSource = dataSet; 
    bindingSource.DataMember = "pcap"; 
    dataGridView.DataSource = bindingSource; 
    // hide the foreign key column
    dataGridView.Columns["idProtocols"].Visible = false;
    // here we populate your comboboxcolumn binding source
    wizardProtocolBindingSource= new BindingSource(); 
    // this dataset is from the protocols table
    wizardProtocolBindingSource.DataSource = dataSet; 
    // Add the combobox column
    DataGridViewComboBoxColumn colType = new DataGridViewComboBoxColumn();      
    colType.HeaderText = "Type";      
    colType.DropDownWidth = 90;      
    colType.Width = 90;      
    colType.DataSource = wizardProtocolBindingSource;      
    // The DataPropertyName refers to the foreign key column on the datagridview datasource
    colType.DataPropertyName = "wizardProtocol";    
    // The display member is the name column in the column datasource  
    colType.DisplayMember = "protocolName";    
    // The value member is the primary key of the protols table  
    colType.ValueMember = "idprotocols";    
    // I usually just add the column but you can insert if you need a particular position  
    dataGridView.Columns.Add(colType);      
      
