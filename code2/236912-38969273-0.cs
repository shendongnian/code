        private void GvRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                dynamic data = e.Row.DataItem;
                TextBox txtType = (TextBox)e.Row.FindControl("txtbox");
                if (data.IsCheked)
                {
                    txtType.Enabled = false;
                }
            }
        }
