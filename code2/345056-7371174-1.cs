    private DataTable DataSource
    {
    get
      {
        string sessionKey = String.Format("DataSource_{0}", this.UniqueID);
        if (Session[sessionKey] == null)
        {
          Session[sessionKey] = new DataTable();
        }
        return Session[sessionKey] as DataTable;
    }
    set
    {
        string sessionKey = String.Format("DataSource_{0}", this.UniqueID);
        Session[sessionKey] = value;
    }
    }
    
    private void ExportToExcel()
    {
       gv.AllowPaging = false;
       gv.DataSource = this.DataSource;
       gv.DataBind();
    }
