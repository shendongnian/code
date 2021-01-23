    int numberOfBytesToRead = 125;
    if (bBuffer.Count >= numberOfBytesToRead)
    {
    	this.Invoke(new Action(() =>
    		listBox1.Items.Add(string.Format("SP: {0}, HR: {1}, Time: {2}", 
    											bBuffer[43].ToString(),
    											bBuffer[103].ToString(),
    											DateTime.Now.ToString()                    
    	))));
    	bBuffer.RemoveRange(0, numberOfBytesToRead);
    }
    			
    using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BMS.Properties.Settings.BMS"].ConnectionString))
    using (var cmd = conn.CreateCommand())
    {       
    	string[] items = listBox1.Items[0].ToString().Split(new char[]{':',','},StringSplitOptions.RemoveEmptyEntries);
    	string sp = items[1];
    	string hr = items[3];
    	string time = items[5];
    	conn.Open();
    	cmd.CommandText = @"INSERT INTO DimRecords (PulseRate,OxygenLevel,PatientID,DateOfMonitoring)  
    						 VALUES (@PR,@OL,@ID,@Date)";
    
    	cmd.Parameters.AddWithValue("@PR", hr);
    	cmd.Parameters.AddWithValue("@OL", sp);
    	cmd.Parameters.AddWithValue("@ID", labelID.Text);
    	cmd.Parameters.AddWithValue("@Date", time);
    
    	int result= cmd.ExecuteNonQuery().ToString();            
    }
    MessageBox.Show((result > 0) ? "Data Inserted" : "Error");
