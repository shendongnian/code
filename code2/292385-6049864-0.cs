    protected void BtnStatusSearch_Click(object sender, EventArgs e)
    {
        SqlDataSource1.SelectCommand = "SELECT Customer.SubId, Customer.CustName, Customer.CustCity, Customer.CustState, Broker.BroName, Broker.BroState, Broker.EntityType, Submission.Coverage, Status.Status FROM Submission INNER JOIN Broker ON Broker.SubId = Submission.SubmissionId INNER JOIN Customer ON Customer.SubId = Submission.SubmissionId INNER JOIN Status ON Status.StatusId = Submission.StatusId WHERE Status.Status = '" + DdlStatus.SelectedItem.Text + "'";
        SqlDataSource1.DataBind();
    }
