        DataSet getRpt()
        {
                CrystalReport1 myRpt = new CrystalReport1();
                string myConstr = ConfigurationManager.AppSettings["ConnectionString"];
                SqlConnection myConnection = new SqlConnection(myConstr);
                SqlDataAdapter myAdapter = new SqlDataAdapter();
                DataSet1 myDataSet = new DataSet1();
                SqlCommand MyCommand = myConnection.CreateCommand();
            try
            {
                CrystalReportViewer1.DisplayGroupTree = false;
                CrystalReportViewer1.DisplayToolbar = true;
                MyCommand.CommandText = "RptPrint";
                MyCommand.CommandType = CommandType.StoredProcedure;
                myAdapter.SelectCommand = MyCommand;
                myAdapter.SelectCommand.Parameters.Add(new SqlParameter("@myDate",Convert.ToInt32(txtDays.Text)));
                myAdapter.Fill(myDataSet, "RptPrint");
                myRpt.SetDataSource(myDataSet);
                CrystalReportViewer1.ReportSource = myRpt;
            }
            catch (Exception ex)
            {
                string strEX;
                strEX = ex.ToString();
                ///Page.ClientScript.RegisterStartupScript(this.GetType(), "Warning", "alert('Enter Day Criteria Please!!!');", true);
            }
            return myDataSet;
        }
        private void Page_Init(object sender, EventArgs e)
        {
            DataSet myD = getRpt();
           
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet myD = getRpt();
        }
        protected void btnPreview_Click(object sender, EventArgs e)
        {
            DataSet myD = getRpt();
          
        }
        protected void CrystalReportViewer1_Init(object sender, EventArgs e)
        {
            
            DataSet myD = getRpt();
        }
        protected void CrystalReportViewer1_Navigate(object source, CrystalDecisions.Web.NavigateEventArgs e)
        {
            DataSet myD = getRpt();
        }
    }
