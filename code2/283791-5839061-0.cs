    string sqlQuery = "INSERT INTO ATI_LOG_IO (Date, Connect_Time, Disconnect_Time, ATI_Rep, Reason_For_Access, Property_Contact, Case_Number, Comments, Property_ID)";
    sqlQuery += " VALUES (@Today, @Connect, @Disconnect, @Rep, @Reason, @Contact, @CaseNum, @Comments, @PropertyID)";
    using (SqlConnection dataConnection = new SqlConnection(connectionString))
    {
        using (SqlCommand dataCommand = new SqlCommand(sqlQuery, dataConnection))
        {
            dataCommand.Parameters.AddWithValue("Today", DateTime.Today.ToString());
            dataCommand.Parameters.AddWithValue("Connect", txtInDate.Text + " " + fromHrs.Text + ":" + fromMins.Text + ":00");
            dataCommand.Parameters.AddWithValue("Disconnect", txtOutdate.Text + " " + toHrs.Text + ":" + fromMins.Text + ":00");
            dataCommand.Parameters.AddWithValue("Rep", repID);
            dataCommand.Parameters.AddWithValue("Reason", txtReason.Text);
            dataCommand.Parameters.AddWithValue("Contact", txtContact.Text);
            dataCommand.Parameters.AddWithValue("CaseNum", txtCaseNum.Text);
            dataCommand.Parameters.AddWithValue("Comments", txtComments.Text);
            dataCommand.Parameters.AddWithValue("PropertyID", lstProperties.SelectedValue);
            dataConnection.Open();
            dataCommand.ExecuteNonQuery();
            dataConnection.Close();
        }
    }
