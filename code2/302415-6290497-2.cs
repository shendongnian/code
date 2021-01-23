    protected void Page_Load(object sender, EventArgs e)
    {
     if(!IsPostBack)
    {
    SqlConnection conn = new SqlConnection("Server=ILLUMINATI;" + "Database=DB;Integrated Security= true");
         SqlCommand comm = new SqlCommand("Select * from FileUpload where UploadedBy='"+NAME+"'",conn);
         try
         {
           conn.Open();
            SqlDataReader rdr = comm.ExecuteReader();
             if (s.Equals("admin"))
             {
                 GridView1.DataSource = rdr;
                 GridView1.DataBind();
                 }
           rdr.Close();
          }
          catch
         {
             conn.Close();
         }
       }
    }
