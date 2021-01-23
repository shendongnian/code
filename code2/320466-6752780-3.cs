    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            var qry = ctx.Categories
                  .Select(c => new {
                      id = c.CategoryID,
                      name = c.CategoryName,
                      desc = c.Description,
                  });
            gdv.DataSource = qry;
            gdv.DataBind();
        }
    }
    protected void gdv_SelectedIndexChanged(object sender, EventArgs e) {
        selectRow();
    }
    private void selectRow() {
        GridViewRow row = gdv.SelectedRow;
        String strId = row.Cells[1].Text; // Bound Field column
        lblSelected.Text = strId;
        // use ID to get object from database...
    }
