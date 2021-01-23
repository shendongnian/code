     protected void GVRowDataBound(object sender, GridViewRowEventArgs e)
            {
                var check = (CheckBox) e.Row.FindControl("ID"); // ID is id of the checkbox
                var lable = (Label) e.Row.FindControl("LableID");
                if(check != null && lable != null)
                {
                    if(check.Checked)
                    {
                        lable.Visible = false;
                    }
                }
             }
