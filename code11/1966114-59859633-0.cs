    You can try below code snippet to get desired output - 
    if (txt_Phone.TextLength >= 3 )
                {
    			if ( dtp_StartDate.Value < dtp_EndDate.Value)
    			{
                    DataTable dt = new DataTable();
                    SqlConnection myConn = new SqlConnection("Data Source=***;Initial Catalog=ViasesTest;User Id=sa;Password=****;MultipleActiveResultSets=true;");
                    myConn.Open();
                    SqlCommand myCmd = new SqlCommand("sp_GetData", myConn);
                    myCmd.Parameters.AddWithValue("@StartDate", dtp_StartDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                    myCmd.Parameters.AddWithValue("@EndDate", dtp_EndDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                    myCmd.Parameters.AddWithValue("@Phone", txt_Phone.Text.ToString().Trim());
                    myCmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(myCmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
    				}
    				else
    				{
    				MessageBox.Show("Start Date can not bigger than Stop Date");
    				}
                }
      else
       {
         MessageBox.Show("'Enter more than 3 characters");
       }
