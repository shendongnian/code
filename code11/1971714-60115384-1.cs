    List<Trans_energycons_ReportModel> model = new List<Trans_energycons_ReportModel>();
    using (SqlConnection con = new SqlConnection("constr"))
    {
        con.Open();
        SqlCommand cmd_get_transformer_consumption = new SqlCommand(@"SELECT Date,units from Total_Power", con);
        SqlDataAdapter da_get_trans_consumption = new SqlDataAdapter(cmd_get_transformer_consumption);
        DataTable dt = new DataTable();
        da_get_trans_consumption.Fill(dt);
    
        foreach (DataRow row in dt.Rows)
        {
            string deviceDate = row["Date"].ToString();
            string units = row["units"].ToString();
    
            //Create object here
            Trans_energycons_ReportModel m = new Trans_energycons_ReportModel();
            m.DeviceDate = Convert.ToDateTime(deviceDate);
            m.Units = Convert.ToDouble(units);
            model.Add(m);
        }
    
    }
    return View(model);
