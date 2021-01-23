    protected void uxTreeView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        EntityDataSource2.WhereParameters.Clear();
        EntityDataSource2.AutoGenerateWhereClause = true;
        //alternatively
        //EntityDataSource2.Where = "it.[CategoryID] = @CategoryID";
        EntityDataSource2.WhereParameters.Add("CategoryID", TypeCode.Int32, uxTreeView1.SelectedValue);
    }
