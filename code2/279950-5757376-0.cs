     string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        String thisQuery = "INSERT INTO ProductInstance (CustId, BroId, CustName, SicNaic, CustAdd, CustCity, CustState, CustZip, BroName, BroAdd, BroCity, BroState, BroZip, EntityType, Coverage, CurrentCoverage, PrimEx, Retention, EffectiveDate, Commission, Premium, Comments) VALUES ('" + TbCustId.Text + "', '" + TbBroId.Text + "', '" + TbCustName.Text + "', '" + RblSicNaic.SelectedItem + "', '" + TbCustAddress.Text + "', '" + TbCustCity.Text + "', '" + DdlCustState.SelectedItem + "', '" + TbCustZip.Text + "', '" + TbBroName.Text + "', '" + TbBroAddress.Text + "', '" + TbBroCity.Text + "', '" + DdlBroState.Text + "', '" + TbBroZip.Text + "', '" + DdlEntity.SelectedItem + "', '" + TbCoverage.Text + "','" + TbCurrentCoverage.Text + "','" + TbPrimEx.Text + "','" + TbRetention.Text + "','" + TbEffectiveDate.Text + "','" + TbCommission.Text + "','" + TbPremium.Text + "','" + TbComments.Text + "')";
        
        string idQuery = "SELECT SCOPE_IDENTITY() AS LastInsertedProductId";
        using (SqlConnection sqlConn = new SqlConnection(connectionString))
        {
            sqlConn.Open();
            SqlCommand command = new SqlCommand(thisQuery, sqlConn);
            
            SqlCommand idCmd = new SqlCommand(idQuery, sqlConn);
            using (command)
            {
                
                command.ExecuteNonQuery();               
               command.CommandText=idQuery;
               SqlDataReader dr = command.ExecuteReader();
                 dr.Read();
                    int lastInsertedProductId = Convert.ToInt32(dr[0]);
                    Response.Redirect("~/View.aspx?ProductId=" + lastInsertedProductId);
                    
            }
        }
    }
    protected void CalEffectDate_SelectionChanged(object sender, EventArgs e)
    {
        TbEffectiveDate.Text = CalEffectDate.SelectedDate.ToShortDateString();
    }    
