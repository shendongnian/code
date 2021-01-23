    protected void gvVoucherList_PreRender(object sender, EventArgs e)
        {
            try
            {
                int RoleID = Convert.ToInt32(Session["RoleID"]);
                
                switch (RoleID)
                {
                    case 6: gvVoucherList.Columns[11].Visible = false;
                        break;
                    case 1: gvVoucherList.Columns[10].Visible = false;
                        break;
                }
                if(hideActionColumn == "ActionSM")
                {
                    gvVoucherList.Columns[10].Visible = false;
                    hideActionColumn = string.Empty;
                }
            }
            catch (Exception Ex)
            {
                
            }
        }
