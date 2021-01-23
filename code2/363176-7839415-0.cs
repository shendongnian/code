     protected void GVRowDataBound(object sender, GridViewRowEventArgs e)
            {
                var check = (CheckBox) e.Row.FindControl("ID"); // ID is id of the checkbox
                if(check != null)
                {
                    var val = check.Checked;
                }
             }
