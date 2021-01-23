    DataTable dt = (DataTable)ViewState["dt"]; // Retrieving from ViewState 
    protected void btn_Add_Click(object sender, EventArgs e)
    {
    DataTable dt = new DataTable();
    ..............
    dt.Rows.Add();
    ViewState["dt"] = dt; // storing datatable in ViewState
    GridView1.DataSource = dt;
    GridView1.DataBind();
    }
    }
