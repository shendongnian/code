	// Define other methods and classes here
	//Update Button which uses all the userdefined filters
	private async void updateButton_Click(object sender, EventArgs e)
	{
		WaitBarDatagrid.Visible = true; //Progressbar is called WaitBarDatagrid
										//    WaitBarDatagrid.Style = ProgressBarStyle.Marquee;
										//    WaitBarDatagrid.MarqueeAnimationSpeed = 30;
	
		dataGridView1.Visible = false;
	
		string fSize;
		if (FileSizeComboBox.Text == "All Data")
		{ fSize = "0"; }
		else if (FileSizeComboBox.Text == "> 1 MB")
		{ fSize = "1000"; } // 1MB = 1000kB 
		else if (FileSizeComboBox.Text == "> 10 MB")
		{ fSize = "10000"; } // 10MB = 10.000kB
		else if (FileSizeComboBox.Text == "> 100 MB")
		{ fSize = "100000"; } // 100MB = 100.000kB 
		else if (FileSizeComboBox.Text == "> 1 GB")
		{ fSize = "1000000"; } // 1 GB = 1000.000 kB
		else
			fSize = "0";
	
		// The following ensures that all possibilities of User Definition are covered
		string user = "";
		string size = "";
		string sep = ""; //Seperator
	
		if (!string.IsNullOrEmpty(UserTextbox.Text))
		{
			user = $"[UserID] = '{UserTextbox.Text}'";
			sep = "AND";
		}
	
		if (!string.IsNullOrEmpty(FileSizeComboBox.Text))
		{
			size = $"{sep} [File Size] >= {fSize}";
			sep = "AND";
		}
	
		//Final Where CLAUSE based on User Input
		//string command = $@"{user} {size}{sep} [Date] <= {DateBox.Value.ToOADate()}";
		string command = $@"{user} {size} {sep} [Date] <= {DateBox.Value.ToOADate()}";
	
		await Task.Run(() => QueryToExcel(command, RootCombobox.Text));
		dataGridView1.DataSource = FileInfos;
		WaitBarDatagrid.Visible = false;
		dataGridView1.Visible = true;
	}
	
	private void QueryToExcel(string command, string RootCombobox_Text)
	{
		//Call Data from Excel
		string connectionString = GetConnectionString(Datapath + RootCombobox_Text);
		string query = $@"SELECT * from [FileInfos$]  WHERE ({command})";
		DataTable dt = new DataTable();
	
		using (OleDbConnection conn = new OleDbConnection(connectionString))
		{
			conn.Open();
			using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, conn))
			{
				try
				{
					dataAdapter.Fill(dt);
					this.Invoke((MethodInvoker)delegate () { FileInfos = dt; });
				}
				catch (System.Data.OleDb.OleDbException ex)
				{
					this.Invoke((MethodInvoker)delegate () { MessageBox.Show(ex.ToString()); });
				}
			}
		}
	}
