    var dt = (ViewState["GV1_DT"] as DataTable) ?? new DataTable(); // -- PULL
    if (dt.Columns.Count == 0)
    {
        dt.Columns.Add("Field");
        dt.Columns.Add("Value");
    }
    DataRow dr = dt.NewRow();
    dr["Field"] = DropDownList1.SelectedValue;
    dr["Value"] = TextBox2.Text.Trim();
    dt.Rows.Add(dr);
    ViewState["GV1_DT"] = dt;    // -- SET
    GridView1.DataSource = dt;
    GridView1.DataBind();
