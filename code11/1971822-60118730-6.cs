    private void DisplayData()
    {
        // am assuming your grid view control name is dataGridView1. Otherwise, please replace with your control name.
    	// Initialize the DataGridView.
    	dataGridView1.AutoGenerateColumns = false;
    	dataGridView1.AutoSize = true;
    
    	// Initialize and add a text box column.
    	DataGridViewColumn column = new DataGridViewTextBoxColumn();
    	column.DataPropertyName = "WeatherData.date";
    	column.Name = "Date";
    	dataGridView1.Columns.Add(column);
    
    	// same for other 3 columns - precipitation, hightemp and lowtemp
    
    	// Now bind data
    	datagridview.DataSource = weatherList;
    }
