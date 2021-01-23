        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
          Control ctl = e.CommandSource as Control;
          GridViewRow CurrentRow = ctl.NamingContainer as GridViewRow;
          object objTemp = gvUsers.DataKeys[CurrentRow.RowIndex].Value as object;
          if (objTemp != null)
          {
              string id = objTemp.ToString();
     //Do your operations
          }
        }
