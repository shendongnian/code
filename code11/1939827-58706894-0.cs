    protected void ViewData_Load(object sender, EventArgs e)
    {
        using (var files = new DBEntitiesModelConn())
        {
            var ViewData= from i in files.LicenseApplicationCPs
                                  select new
                                      {
                                          Name = i.Name,
                                          Status = i.Status,
                                          Date = i.DateSubmitted,
                                      };
            ViewDataGrid.DataSource = ViewData.ToList();
            ViewDataGrid.DataBind();
        }
    }
