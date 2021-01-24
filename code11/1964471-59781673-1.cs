    private static string _REQID = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        _REQID = Request["id"];
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["PROJECTS"].ConnectionString);
        DataTable dt = new DataTable();
        con1.Open();
        SqlDataReader myReader = null;
        SqlCommand myCommand = new SqlCommand($"SELECT id, " +
            $"Date, " +
            $"Number, " +
            $"CustomerName, " +
            $"AccpacPcNo, " +
            $"CRMCaseNo, " +
            $"ProjectDetails, " +
            $"TechnicalResourceAssigned," +
            $"ProjectPhase, " +
            $"WorkHours, " +
            $"PlannedCompletionDate, " +
            $"Comments FROM tbl_projects WHERE ID=@ReqID", con1);
            myCommand.Parameters.AddWithValue("@ReqID", _REQID );
    
        myReader = myCommand.ExecuteReader();
    
        while (myReader.Read())
        {
            txtProjectDate.Text = (myReader["Date"].ToString());
            txtProjectNumber.Text = (myReader["Number"].ToString());
            txtProjectCustomerName.Text = (myReader["CustomerName"].ToString());
            txtProjectAccpacNumber.Text = (myReader["AccpacPcNo"].ToString());
            txtProjectCRMCaseNumber.Text = (myReader["CRMCaseNo"].ToString());
            txtProjectDetails.Text = (myReader["ProjectDetails"].ToString());
            txtProjectTechnicalResourceAssigned.Text = (myReader["TechnicalResourceAssigned"].ToString());
            txtProjectPhase.SelectedItem.Text = (myReader["ProjectPhase"].ToString());
            txtProjectWorkHours.Text = (myReader["WorkHours"].ToString());
            txtProjectPlannedCompletionDate.Text = (myReader["PlannedCompletionDate"].ToString());
            txtProjectComments.Text = (myReader["Comments"].ToString());
        }
        con1.Close();
    }
    
    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PROJECTS"].ConnectionString);
        SqlCommand cmd = new SqlCommand($"UPDATE tbl_projects SET [Date] = @Date, " +
            $"[Number] = @Number, " +
            $"[CustomerName] = @CustomerName, " +
            $"[AccpacPcNo] = @AccpacPcNo, " +
            $"[CRMCaseNo] = @CRMCaseNo, " +
            $"[ProjectDetails] = @ProjectDetails, " +
            $"[TechnicalResourceAssigned] = @TechnicalResourceAssigned, " +
            $"[ProjectPhase] = @ProjectPhase, " +
            $"[WorkHours] = @WorkHours, " +
            $"[PlannedCompletionDate] = @PlannedCompletionDate, " +
            $"[Comments] = @Comments FROM tbl_Projects WHERE ID = @ReqID", con);
    
        con.Open();
    
        cmd.Parameters.AddWithValue("@Date", txtProjectDate.Text);
        cmd.Parameters.AddWithValue("@Number", txtProjectNumber.Text);
        cmd.Parameters.AddWithValue("@CustomerName", txtProjectCustomerName.Text);
        cmd.Parameters.AddWithValue("@AccpacPcNo", txtProjectAccpacNumber.Text);
        cmd.Parameters.AddWithValue("@CRMCaseNo", txtProjectCRMCaseNumber.Text);
        cmd.Parameters.AddWithValue("@ProjectDetails", txtProjectDetails.Text);
        cmd.Parameters.AddWithValue("@TechnicalResourceAssigned", txtProjectTechnicalResourceAssigned.Text);
        cmd.Parameters.AddWithValue("@ProjectPhase", txtProjectPhase.SelectedItem.ToString());
        cmd.Parameters.AddWithValue("@WorkHours", txtProjectWorkHours.Text);
        cmd.Parameters.AddWithValue("@PlannedCompletionDate", txtProjectPlannedCompletionDate.Text);
        cmd.Parameters.AddWithValue("@Comments", txtProjectComments.Text);
    
        cmd.Parameters.AddWithValue("@ReqID", _REQID);
        cmd.ExecuteNonQuery();
        con.Close();
    }
