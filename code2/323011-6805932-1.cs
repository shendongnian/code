    private void button3_Click(object sender, EventArgs e)
    {
       string strcon = "Data Source=PINKAL-PC; initial catalog=testing; integrated security=SSPI;";
    
       // Put your SqlConnection into using blocks to ensure proper disposal
       using(SqlConnection sqlcon = new SqlConnection(strcon))
       { 
         //  sqlcon.Open();  -- don't open it here already - open as LATE as possible....
         // for SqlDataAdapter - you don't even need to open it yourself - 
         // the data adapter will do this automatically for you
         // and **IF** you open it yourself - you also need to CLOSE it again!
    
         // *NEVER* use SELECT * in code !! specify the columns you want explicitly
         // string strquery = "select * from testimg";
         string strquery = "SELECT col1, col2, col3 ..... FROM dbo.testimg";  
    
         SqlDataAdapter da = new SqlDataAdapter(strquery, sqlcon);
 
         //DataSet ds = new DataSet();  if you only want a single DataTable - no point in having a  whole DataSet ! That's just overhead.....
         //da.Fill(ds);
         //DataTable dt = new DataTable();
         //dt = ds.Tables[0];
         DataTable dt = new DataTable();
         da.Fill(dt);
         // is there a "image" column in your table?? 
         // You need to use the proper column name here!
         byte[] barrImg = (byte[])dt.Rows[7]["image"];
         MemoryStream mstream = new MemoryStream(barrImg);
    
         pictureBox2.Image = Image.FromStream(mstream);
      }
    }
