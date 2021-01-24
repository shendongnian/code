    public void Test()
        {
            //you can see all type of connection string for sql server in https://www.connectionstrings.com/sql-server/
            //example of connection string for sql server
            //Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;
            SqlConnection con=new SqlConnection("your connection string");
            SqlCommand cmd;
            string commandText = "INSERT INTO [dbo].['LABTEST$']([EmployeeID],[Company],[Employee Name],[Start Time]"+
                ",[Signature In],[Lunch IN],[Lunch OUT],[End Time],[Hours],[Job],[Period],[Date],[PayID],[Equipment Used],[Injured ?]"+
                ",[Signature OUT],[Superintendent],[Processed By],[Date Processed],[On Time or Late - Proc],[Reported By],[Date Reported]"+
                ",[Hours Late-Rpt],[Job % Complete],[Variances],[Unique ID],[RT Hours WTD],[RT Hours Daily],[OT Hours Daily],[RT $ Daily]"+
                ",[OT $ Daily],[Total $ Daily],[PERDIEM $ Daily ],[HOURS(No PerDiem)],[ID],[SORT]) VALUES(@EmployeeID,@Company)";
            cmd.CommandType = CommandType.Text;
            for (int i = 0; i < GridView2.Rows.Count - 1; i++)
            {
                cmd=new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = commandText;
                cmd.Parameters.AddWithValue("@EmployeeID", GridView2.Rows[i].Cells[0].Value);
                cmd.Parameters.AddWithValue("@Company", GridView2.Rows[i].Cells[1].Value);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                cmd = null;
            }
        }
