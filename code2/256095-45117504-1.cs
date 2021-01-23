    void GetProvince()
    {
        SqlConnection con = new SqlConnection(dl.cs);
        try
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT ProvinceID, ProvinceName FROM Province", con);
            DataTable dt = new DataTable();            
            int i = da.Fill(dt);
                         
            if (i > 0)
            {           
                DataRow row = dt.NewRow();
                row["ProvinceName"] = "<-Selecione a Provincia->";
                dt.Rows.InsertAt(row, 0);
                cbbProvince.DataSource = dt;
                cbbProvince.DisplayMember = "ProvinceName";
                cbbProvince.ValueMember = "ProvinceID";
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
