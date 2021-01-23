    private DataTable DataSource
    {
    get
      {
        if (Session["DataSource"] == null)
        {
          Session["DataSource"] = new DataTable();
        }
        return Session["DataSource"] as DataTable;
    }
    set
    {
        Session["DataSource"] = value;
    }
    }
    
    private void ExportToExcel()
    {
       gv.AllowPaging = false;
       gv.DataSource = this.DataSource;
       gv.DataBind();
    }
