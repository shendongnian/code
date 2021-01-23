    DataGridViewComboBoxColumn colForeign = new DataGridViewComboBoxColumn(); 
    colForeign = MyDB.CreateComboBoxColumn("SELECT subjno,subject FROM subject", "ComboForeign", "subject", "subjno"); 
    colForeign.HeaderText = "Subject"; 
    colForeign.Width = 120; 
    colForeign.DisplayStyle = 0; 
    this.dataGridView2.Columns.Insert(3, colForeign) 
    Use DataPropertyName to get the selected key column as in :- 
    this.dataGridView2.Columns[3].DataPropertyName = "subjno";
