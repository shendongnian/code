    protected void GVSelectedIndexChanged(object sender, GridViewRowEventArgs e)
    {
                var check = (CheckBox) e.Row.FindControl("chb1");
                if(check != null)
                {
                        // do something
                }
    }
