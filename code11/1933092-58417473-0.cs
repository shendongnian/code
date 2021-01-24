     // Holds the actual selected items value
     public string ExpirationIDValue {get; private set;}
     // Anytime the selected index changes, we update our property. You can 
     // put this on the constructor and or on load.
     ExpirationID.SelectedIndexChanged += ExpirationID_SelectedIndexChanged;
     // Event handler for when selection changes
     private void ExpirationID_SelectedIndexChanged(object sender, EventArgs e)
     {
        if (sender is ListBox listBox && listBox.SelectedValue != null)
        {
           ExpirationIDValue = (listBox.SelectedValue.ToString();
        }
     }
     // This was for testing, just to get some data, you can ignore this
     DataTable dataTable = new DataTable();
     dataTable.Columns.Add(new DataColumn("Expireing_ID",typeof(string)));
     dataTable.Columns.Add(new DataColumn("Expireing_ID_Display",typeof(string)));
     int i = 1;
     while(i < 10)
     {
        dataTable.Rows.Add(i.ToString(),$"Display {i}");
        i++;
     }
             
     // Here you need to make sure you set these properties to your actual
     // property names.     
     ExpirationID.DataSource = dataTable;      
     ExpirationID.DisplayMember = "Expireing_ID_Display";
     ExpirationID.ValueMember = "Expireing_ID";
