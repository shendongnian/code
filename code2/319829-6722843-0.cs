    // There Orders is a data table coming from the db which includes the product id column 
    dataGridView1.DataSource = Orders;
    // You set up your column just the same, with the DisplayMember and ValueMember
    DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();         
    GetDisplayAndValueMembers(table, headerText);
    column.DataSource = tableRef; //sets datasource to table referenced by column
    column.DisplayMember = displayMember; //sets displaymember
    column.ValueMember = valueMember; //sets valuemember       
    column.HeaderText = headerText; //changes headertext to displayed text   
    //Now you also set the DataPropertyName
    column.DataPropertyName = "ProductId"; // this is the name of a column or property from the grid datasource
    dataGridView1.Columns.Add(column);
