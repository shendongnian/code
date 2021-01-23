    protected void Page_Load(object sender, EventArgs e)
    {
        dta_grd = new DataGrid();
        dta_grd.DataSource = Ex_DLL.GetData("select * from tstint/m02");
        dta_grd.DataBind(); // this method populates the DataGrid from assigned datasource
        PlaceHolder1.Controls.Add(dta_grd);
    
        Lbl_Dsply.Visible = true;
        if (Supp_Data.Items.Count == 0)
        {
            Lbl_Dsply.Text = "No Records Found!";
        }
        else
        {
            Lbl_Dsply.Text += dta_grd.Items.Count.ToString();
        }
    }
