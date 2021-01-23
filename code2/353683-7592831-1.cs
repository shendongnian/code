        DataTable t ....
        t.DefaultView.Sort="SortExpressionColumn1 ASC/DESC , SortExpressionColumn2 ASC/DESC";
        gvResults.DataSource=t.DefaultView.ToTable();
        gvResults.DataSource=t.DataBind();
 
