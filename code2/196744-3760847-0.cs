    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridFunction();
        }
    }
    private void BindGridFunction()
    {
        try
        {
            DataTable DT = new DataTable();
            using (SqlConnection con = Connection.GetConnection())
            {
                if(DDlCity.SelectedIndex <0)
                {
                    SqlCommand Com = new SqlCommand("GetDealers", con);
                    Com.CommandType = CommandType.StoredProcedure;
                }
                else
                {
                    SqlCommand Com = new SqlCommand("GetDealersByArea", con);
                    Com.CommandType = CommandType.StoredProcedure;
                    Com.Parameters.Add(Parameter.NewInt("@DEALERAREA_ID", DDlCity.SelectedItem.Value));
                }
                SqlDataAdapter DA = new SqlDataAdapter(Com);
                DA.Fill(DT);
                GridView1.DataSource = DT;
                GridView1.DataBind();
            }
        }
        catch(Exception ex)
        {
            DT = null; // etc...etc.. clear objects created
        }
    }
    protected void DDlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGridFunction();
    }
