    try
        {
            DataTable dt1 = dt; // Set breakpoint here; check dt1 and dl1 to pinpoint prob
            DataList dl1 = (DataList) this.FindControl("dlspec");
            dl1.DataSource = dt1;
            dl1.DataBind();
        }
        catch (Exception ex)
        {
            throw;
        }
