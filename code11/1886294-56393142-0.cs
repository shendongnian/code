    protected void UpdateTable(object sender, EventArgs e)
            {
                foreach (GridViewRow item in GridView1.Rows)
                {
                    CheckBox chk = (CheckBox)item.FindControl("CheckBox1");
                    if (chk != null)
                    {
                        //This is being written and always false
                        Response.Write(chk.Checked);
                        if (chk.Checked)
                        {
                            //Delete the item. (never being executed)
                        }
                    }
                    LinkButton lnk = (LinkButton)item.FindControl("LinkButton2");
                    if (lnk != null)
                    {
                        Response.Write(lnk.Text);
                    }
                }
            }
