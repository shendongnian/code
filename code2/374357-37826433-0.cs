        protected void FormatPaskWeeksPerStudentRow(GridViewRow gvRow)
        {
                SqlDataSource sdsTETpastWeeks = (SqlDataSource)gvRow.FindControl("sdsTETpastWeeks");
                sdsTETpastWeeks.SelectParameters["StudentID"].DefaultValue = hfStudentID.Value.ToString();
                if (sdsTETpastWeeks != null)
                {
                    CheckBoxList cbl1 = (CheckBoxList)gvRow.FindControl("listWeeksTracking");
                    if (cbl1 != null)
                    {
                        cbl1.DataBind();
    
                        foreach (ListItem litem in cbl1.Items)
                        {
                            //disable the checkbox for now
                            litem.Enabled = false;
    
                            //see if any of the past weeks (excluding this week) needs to be highlighted as a hyperlink to show past comments
                            //get the Tracking value. If set, then mark the checkbox as Selected or Checked
                            DataSourceSelectArguments dss = new DataSourceSelectArguments();
                            DataView dv = sdsTETpastWeeks.Select(dss) as DataView;
                            DataTable dt = dv.ToTable() as DataTable;
                            if (dt != null)
                            {
                                //this loops through ALL the weeks available to the student, for this block
                                //it tries to match it against the current ListItem for the week it's loading and determines if they match
                                //if so then mark the item selected (checked=true) if the value in the sub query says it's true
                                foreach (DataRow dr in dt.Rows)
                                {
                                    if (litem.Text == dr.ItemArray[0].ToString() && litem.Text != ddlWeekNo.SelectedItem.Text)
                                    {
                                        if ((bool)dr.ItemArray[1])
                                            litem.Selected = true;
    
                                        //for those that were not ticked in prior weeks, make a ToolTip with the text/comment made in that week and underscore the week number
                                        else
                                        {
                                            litem.Attributes["title"] = dr.ItemArray[2].ToString();
                                            litem.Attributes.Add("style", "color:Blue;font-style:italic;text-decoration:underline;");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
    }
