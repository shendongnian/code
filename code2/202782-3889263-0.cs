    protected void Page_Load(object sender, EventArgs e)
    {
        if(!isPostBack)
        {     
            myPlaceholder.Visible = false;
        }
    }
    
    protected void SqlDataSource1_Selected(object sender, SqlDataSourceStatusEventArgs e)
    {
        myPlaceholder.Visible = e.AffectedRows > 0;
    }
