     protected void Page_Load(object sender, EventArgs e)
    {
        string x = Request.QueryString["ProductId"];
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        string editQuery = "SELECT CustName, SicNaic, CustCity, CustAdd, CustState, CustZip, BroName, BroAdd, BroCity, BroState, BroZip, EntityType, Coverage, CurrentCoverage, PrimEx, Retention, EffectiveDate, Commission, Premium, Comments FROM ProductInstance WHERE ProductId =" + x;
        using (SqlConnection editConn = new SqlConnection(connectionString))
        {
            editConn.Open();
            using (SqlCommand command = new SqlCommand(editQuery, editConn))
            {
                SqlDataReader dr = command.ExecuteReader();
                dr.Read();
                LblCustName.Text = dr.GetString(0);
                LblSicNaic.Text = dr.GetString(1);
                LblCustCity.Text = dr.GetString(2);
                LblCustAddress.Text = dr.GetString(3);
                LblCustState.Text = dr.GetString(4);
                LblCustZip.Text = dr.GetInt32(5).ToString();
                LblBroName.Text = dr.GetString(6);
                LblBroAddress.Text = dr.GetString(7);
                LblBroCity.Text = dr.GetString(8);
                LblBroState.Text = dr.GetString(9);
                LblBroZip.Text = dr.GetInt32(10).ToString();
                LblEntity.Text = dr.GetString(11);
                LblCoverage.Text = dr.GetInt32(12).ToString();
                LblCurrentCoverage.Text = dr.GetInt32(13).ToString();
                LblPrimEx.Text = dr.GetInt32(14).ToString();
                LblRetention.Text = dr.GetInt32(15).ToString();
                LblEffectDate.Text = dr.GetDateTime(16).ToString();
                LblCommission.Text = dr.GetInt32(17).ToString();
                LblPremium.Text = dr.GetInt32(18).ToString();
                LblComments.Text = dr.GetString(19);
                HyperLink1.NavigateUrl = "~/ViewEdit.aspx?ProductId=" + x;
            }
        }
    }
}
