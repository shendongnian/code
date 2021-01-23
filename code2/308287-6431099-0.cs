    private ConnectionInfo crConnectionInfo = new ConnectionInfo();
            ReportDocument rpt = new ReportDocument();
            protected void Page_Load(object sender, EventArgs e)
            {
                CrystalReportViewer1.Width = 900;
                CrystalReportViewer1.ToolPanelView = ToolPanelViewType.None;
                BindReport();
            }
    
            private void BindReport()
            {
               
                rpt.Load(Server.MapPath("ProductList.rpt"));
                DataSet ds = getReportData();
                rpt.SetDataSource(ds.Tables[0]);
                CrystalReportViewer1.ReportSource = rpt;
            }
    
            private DataSet getReportData()
            {
                DataSet ds = new DataSet();
                string ConnectionString = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
                SqlConnection con = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "GetProductList";
                cmd.CommandType = CommandType.StoredProcedure;            
                con.Open();
                cmd.Connection = con;
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(ds, "ctable");
                con.Close();
                return ds;
            }
