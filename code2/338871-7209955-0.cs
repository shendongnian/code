     protected void HlnkbInsert_Click(object sender, EventArgs e)
     {
         ...
         gv.EditIndex = -1;
         DataBindGV();
    
     }
    
    protected void gv_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
         ...
         gv.EditIndex = -1;
         DataBindGV();
    }
    
     protected void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
     {
         ...
         gv.EditIndex = -1;
         DataBindGV();
    }
    
    protected void gv_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
         ...
         gv.EditIndex = e.NewSelectedIndex;
         DataBindGV();
    }
