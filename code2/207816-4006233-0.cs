    const int ColumnSelect = 0;
    protected void Page_Load(object sender, EventArgs e)
    {       
        //Get real data here.
        DataTable dt = new DataTable();
        dt.Columns.Add("count");                
        dt.Rows.Add(dt.NewRow());
        dt.Rows[0][0] = "5";
                
        GridView1.Columns.Add(new TemplateField());        
        BoundField b = new BoundField();
        GridView1.Columns.Add(b);
        b.DataField = "count";
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.Header)
        {            
            e.Row.Cells[ColumnSelect].Controls.Add(new CheckBox());
        }
    }
