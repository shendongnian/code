    protected void GVSearchResults_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                
                foreach (GridViewRow gvr in gvSearchResults.Rows)
                {
                    if (gvr.RowType == DataControlRowType.DataRow)
                    {
                        if (((Label)gvr.FindControl("lblStudentID")).Text == e.CommandArgument.ToString())
                        {
                            bool isChecked = ((CheckBox)gvr.FindControl("cbStudent")).Checked;
                            int count = 0;
                            if (e.CommandName == "Save")
                            {
                                this.SaveStudentcheck(int.Parse(e.CommandArgument.ToString()));
                            }
                            break;
                        }
                    }
                }
                gvSearchResults.DataBind();            
            }
