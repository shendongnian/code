    private async Task ConsumeData()
    {
	  DataTable dt = null;
	  try
	  {
	  	dt = await GetData(1, DateTime.Now);
	  }
	  catch (Exception Ex)
	  {
		// do something if an error occurs
		System.Diagnostics.Debug.WriteLine("Error occurred: " + Ex.ToString());
		return;
	  }
	  foreach(DataRow dr in dt.Rows)
	  {
		System.Diagnostics.Debug.WriteLine(dr.ToString());
	  }
    }
    private async void button1_Click(object sender, EventArgs e)
    {
	  await ConsumeData();
    }
