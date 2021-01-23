    SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=EMS;User ID=sa;Password=sa123");
    string SQL1 = "SELECT coursename,coursefees,batchname FROM  CourseMaster,BatchMaster WHERE CourseMaster.coursemasterid=BatchMaster.coursemasterid and CourseMaster.coursemasterid="+coursemasterid+" and BatchMaster.batchmasterid="+batchmasterid+"";
    SqlCommand cmd = new SqlCommand(SQL1, con);
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    DataTable ds = new DataTable();
    //DataColumn faculty = new DataColumn();
    da.Fill(ds);
    GridView1.DataSourceID = null;
    //New Code Added Here
    DataRow row = ds.NewRow();
    //your columns
    row["columnOne"] = valueofone;
    row["columnTwo"] = valueoftwo;
    ds.Rows.Add(row);
    //=========
    GridView1.DataSource = ds;
    GridView1.DataBind();     
