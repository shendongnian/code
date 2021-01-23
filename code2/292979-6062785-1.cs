    void SetupDataSource(DropDownList ddl, DataTable dt, string dataValueFieldm, string dataTextField)
    {
        if (ddl != null)
        {
            ddl.DataValueField = dataValueField;
            ddl.DataSource = dt;
            if (!string.IsNullOrEmpty(dataTextField)) 
            {
                ddl.DataTextField  = dataTextField;
            }
            ddl.DataBind();
        }
        else
        {
           throw new ArgumentNullException("ddl");
        }
    }
