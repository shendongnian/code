    protected void BindData()
    {
        DataTable dt = DAL.GetData(...
        if(dt.Rows.Count == 0)
        {
            dt.Rows.Add(dt.NewRow());
        }
        DataList.DataSource = dt;
        DataList.DataBind();
    }
