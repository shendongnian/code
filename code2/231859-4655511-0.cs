    protected void Page_Load(object sender, EventArgs e) {
        ASPxGridView grid = new ASPxGridView();
        grid.ID = "grid";
        pnl.Controls.Add(grid);
        DataTable t = new DataTable();
        t.Columns.Add("Id");
        t.Columns.Add("Data");
        for(int i = 0; i < 100; i++) {
            t.Rows.Add(new object[] { i, "row " + i.ToString() });
        }
        grid.DataSource = t;
        grid.Settings.ShowGroupPanel = true;
        grid.DataBind();
    
        (grid.Columns["Data"] as GridViewDataColumn).GroupBy();
    }
