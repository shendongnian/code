     protected void gvShowRegistration_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvShowRegistration.EditIndex = e.NewEditIndex;
            Binddata(); 
        }
    protected void gvShowRegistration_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvShowRegistration.EditIndex = -1;
            Binddata();
        }
