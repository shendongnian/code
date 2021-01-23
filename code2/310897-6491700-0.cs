    public string WriteResult(DataTable dt)
    {
        DataGrid dg = new DataGrid();
        dg.CellPadding = 5;
        dg.BackColor = System.Drawing.Color.White;
        dg.BorderColor = System.Drawing.Color.Gray;
        dg.Font.Name = "Arial";
        dg.Font.Size = FontUnit.XSmall;
        dg.HeaderStyle.Font.Bold = true;
        dg.FooterStyle.Font.Bold = true;
        dg.DataSource = dt;
        dg.DataBind();
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        dg.RenderControl(hw);
        return sw.ToString();
    }
