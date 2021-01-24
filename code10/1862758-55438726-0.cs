    private void AddNewRowToGrid()
        {
               try
              {
                int serialNumber = 0, preference = 0;
                if (SerialNum.Text != "0")
                {
                    serialNumber = Int32.Parse(SerialNum.Text.ToString());
                }
                if (ddlPreferenceLottery.SelectedValue != "0")
                {
                    preference = Int32.Parse(ddlPreferenceLottery.SelectedValue.ToString());
                }
                DataTable griddt;
                DataTable griddt2;
                if (ViewState["Row"] != null)
                {
                    griddt = (DataTable)(ViewState["Row"]);
                    DataRow dr = null;
                    if (griddt.Rows.Count > 0)
                    {
                        griddt2 = DL_School_Detail.getLotteryApplications(serialNumber, preference);
                        griddt.Merge(griddt2, true, MissingSchemaAction.Ignore);
                        if (griddt.Rows.Count > 0)
                        {
                            ViewState["Row"] = griddt;
                            ContentPlaceHolder1_selectedStudentView.DataSource = griddt;
    
                            ContentPlaceHolder1_selectedStudentView.DataBind();
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('कृपया सही सीरियल नंबर और  प्राथमिकता चुने !')", true);
                        }
                    }
    
                }
                else
                {
                    DataTable dt = DL_School_Detail.getLotteryApplications(serialNumber, preference);
                    //dt.Merge(griddt, true, MissingSchemaAction.Ignore);
                    if (dt.Rows.Count > 0)
                    {
                        ViewState["Row"] = dt;
                        ContentPlaceHolder1_selectedStudentView.DataSource = ViewState["Row"];
    
                        ContentPlaceHolder1_selectedStudentView.DataBind();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('कृपया सही सीरियल नंबर और  प्राथमिकता चुने !')", true);
                    }
                }
            }
            catch (Exception ex)
            {
    
            }
        }
