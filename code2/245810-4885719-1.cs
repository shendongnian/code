    public static void BindDropDownList(DataTable _dt, System.Web.UI.WebControls.DropDownList _ddl, bool IsDIndex,string text)
    {
        try
        {
            _ddl.DataSource = _dt;
            _ddl.DataBind();
            if (IsDIndex == true)
            {
                _ddl.Items.Insert(0, new ListItem(text, "0"));
            }
        }
        catch (Exception ex)
        {
            General.ErrorLog(ex.Message + " Stack Trace: " + ex.StackTrace, System.Diagnostics.EventLogEntryType.Error, "General - BindDropDownList()");
        }
    }
