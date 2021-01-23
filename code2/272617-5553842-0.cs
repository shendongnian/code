    protected void SqlDataSource1_Selected(object sender, SqlDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            // do something
            e.ExceptionHandled = true;
        }
    }
