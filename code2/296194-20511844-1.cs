            try
            {
                DataSet ds = GetData("qtp_getservice");
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //services,environment,platform
                    // bool flag = false;
                
                    if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
                    {
                        Label lbl = (Label)e.Row.FindControl("LblScenarioStatus");
                        if (null != lbl && lbl.Text != "")
                        {
                            lbl.Text = (string.Compare(lbl.Text, "True", true) == 0) ? "Enabled" : "Disabled";
                        }
                    }
                  if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) == DataControlRowState.Edit)
                   // {
                       // for (int i = 0; i < grdScenario.Rows.Count ; i++)
                       // {
                   // foreach (GridViewRow gvRow in grdScenario.Rows)
                    {
                        DropDownList ddlApp = (DropDownList)e.Row.FindControl("ddlAppDataRow");
                        DropDownList ddlTT = (DropDownList)e.Row.FindControl("ddlTestTypeDataRow");
                        DropDownList ddlST = (DropDownList)e.Row.FindControl("ddlScenarioTypeDataRow");
                        //Label lblapp = ((Label)e.Row.Cells[2].FindControl("lblapp"));
                        //Label lblTestType = ((Label)e.Row.Cells[3].FindControl("lblTestType"));
                        //Label lblScenarioType = ((Label)e.Row.Cells[4].FindControl("lblScenarioType"));
                        // Label lblapp = ((Label)grdScenario.Rows[i].Cells[2].FindControl("lblapp"));
                        //Label lblTestType = ((Label)grdScenario.Rows[i].Cells[3].FindControl("lblTestType"));
                        // Label lblScenarioType = ((Label)grdScenario.Rows[i].Cells[4].FindControl("lblScenarioType"));
                        if (ddlApp != null)
                        {
                            HiddenField hdnAppid = (HiddenField)e.Row.FindControl("hdnAppid");
                            ddlApp.DataSource = ds.Tables[4].DefaultView;
                            ddlApp.DataTextField = "AppName";
                            ddlApp.DataValueField = "SNO";
                            ddlApp.DataBind();
                            //ddlApp.SelectedIndex = ddlApp.Items.IndexOf(ddlApp.Items.FindByText(grdScenario.DataKeys[e.Row.RowIndex].Values[1].ToString()));
                            //ddlApp.SelectedItem.Text = lblapp.Text.ToString();
                            ddlApp.SelectedValue = hdnAppid.Value;
                        }
                        if (ddlTT != null)
                        {
                            HiddenField hdnTesttype = (HiddenField)e.Row.FindControl("hdnTesttype");
                            ddlTT.DataSource = ds.Tables[5].DefaultView;
                            ddlTT.DataTextField = "Testingtypedescription";
                            ddlTT.DataValueField = "TestingTypeID";
                            ddlTT.DataBind();
                            //ddlTT.SelectedItem.Text = lblTestType.Text.ToString();
                            ddlTT.SelectedValue = hdnTesttype.Value; 
                            //ddlTT.SelectedIndex = ddlTT.Items.IndexOf(ddlTT.Items.FindByText(grdservices.DataKeys[e.Row.RowIndex].Values[2].ToString()));
                        }
                        if (ddlST != null)
                        {
                            HiddenField hdnScenariotype = (HiddenField)e.Row.FindControl("hdnScenariotype");
                            ddlST.DataSource = ds.Tables[6].DefaultView;
                            ddlST.DataTextField = "ScenarioTypeDescription";
                            ddlST.DataValueField = "ScenarioTypeID";
                            ddlST.DataBind();
                            ddlST.SelectedValue = hdnScenariotype.Value;
                            //ddlST.SelectedItem.Text = lblScenarioType.Text.ToString();
                            //ddlST.SelectedIndex = ddlST.Items.IndexOf(ddlST.Items.FindByText(grdScenario.DataKeys[e.Row.RowIndex].Values[3].ToString()));
                        }
                    }
                       // }
                   //// }
                }
                if (e.Row.RowType == DataControlRowType.Footer)
                {
                    //Bind environment,platform at footer.
                    DropDownList cmbNewType = (DropDownList)e.Row.FindControl("ddlAppFooter");
                    cmbNewType.DataSource = ds.Tables[4].DefaultView;
                    cmbNewType.DataBind();
                    DropDownList cmbNewType1 = (DropDownList)e.Row.FindControl("ddlTestTypeFooter");
                    cmbNewType1.DataSource = ds.Tables[5].DefaultView;
                    cmbNewType1.DataBind();
                    DropDownList cmbNewType2 = (DropDownList)e.Row.FindControl("ddlScenarioTypeFooter");
                    cmbNewType2.DataSource = ds.Tables[6].DefaultView;
                    cmbNewType2.DataBind();
                }
            }
            catch (System.Exception) { }
        }
