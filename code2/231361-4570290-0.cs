    protected void Bindgrid(DataTable dt)
    {
       if (dt != null)
       { 
         if (dt.rows.count > 0)
         {
             gvYourGrid.DataSource = dt;
             gvYourGrid.DataBind();
         }
       }
    }
