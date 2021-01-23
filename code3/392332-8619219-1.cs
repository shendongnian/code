    private void GridLoad();
    {
    if(Session["myDatatable"]==null)
    {
    ASPxGridView1.DataSource = SP1;
    ASPxGridView1.DataBind();
    }
    else
    {
    ASPxGridView1.DataSource = (DataTable)Session["myDatatable"];
    ASPxGridView1.DataBind();
    }
    }
