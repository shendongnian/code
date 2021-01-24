    string TDate = string.Empty;
    if(string.IsNullOrEmpty(txtdate.Text))
    {
       TDate = DateTime.Now.ToString("dd/MM/yyyy"); 
    }
    else
    {
       TDate = txtdate.Text;
    }
    SqlCommand cmd = new SqlCommand("select * from HomeWork where Date = '" + TDate  + "'  AND school_id='" + a + "' AND Standard='" + ds_std.Tables[0].Rows[0]["CurrentStd"].ToString() + "'", dbcon);
    SqlDataAdapter sda = new SqlDataAdapter(cmd);
    DataSet ds = new DataSet();
    sda.Fill(ds);
    gvhw.DataSource = ds;
    gvhw.DataBind();
