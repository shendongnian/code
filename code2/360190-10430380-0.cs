        try
        {
            if (clsGeneral._strRights[2] == "0")
            {
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "ShowAlert", "ShowAlert();", true);               
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowUnAuthorisedMsg", "ShowUnAuthorisedMsg();", true);
                Response.Redirect("UnauthorizedUser.aspx");
            }
            else
            {
                GridViewRow gvRow = (GridViewRow)gvGeneralMaster.Rows[e.NewEditIndex];
                ViewState["COUNTRY"] = ((Label)gvRow.FindControl("lblCountry")).Text.Trim();
                ViewState["STATE"] = ((Label)gvRow.FindControl("lblState")).Text.Trim();
                gvGeneralMaster.EditIndex = e.NewEditIndex;
                GetGeneralDetails();
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message.ToString();
            if (!ex.Message.ToString().Contains("Thread was being aborted."))
            {
                //oBL_ClsLog.SaveLog(Convert.ToString(Session["CurrentUser"]).Trim(), "Exception", ex.Message.ToString(), "GROUP MASTER");
                ErrMsg = ex.Message.ToString(); try { string[] arrErr = ex.Message.ToString().Split('\n'); ErrMsg = arrErr[0].ToString().Trim(); }
                catch { } Response.Redirect("Error.aspx?Error=" + ErrMsg.ToString().Trim());
            }
        }
    }
    protected void gvGeneralMaster_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            if (clsGeneral._strRights[2] == "0")
            {
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "ShowAlert", "ShowAlert();", true);               
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ShowUnAuthorisedMsg", "ShowUnAuthorisedMsg();", true);
                Response.Redirect("UnauthorizedUser.aspx");
            }
            else
            {
                GridViewRow gvRow = (GridViewRow)gvGeneralMaster.Rows[e.RowIndex];
                oPRP._GeneralCode = int.Parse(((Label)gvRow.FindControl("lblEGenCode")).Text.Trim());
                oPRP._GenaralName = ((TextBox)gvRow.FindControl("txtECity")).Text.Trim();
                oPRP._StateName = ((DropDownList)gvRow.FindControl("ddlEState")).SelectedItem.Text.Trim() != "SELECT" ? ((DropDownList)gvRow.FindControl("ddlEState")).SelectedItem.Text.Trim() : "";
                oPRP._CountryName = ((DropDownList)gvRow.FindControl("ddlECountry")).SelectedItem.Text.Trim() != "SELECT" ? ((DropDownList)gvRow.FindControl("ddlECountry")).SelectedItem.Text.Trim() : "";
                oPRP._Remarks = ((TextBox)gvRow.FindControl("txtERemarks")).Text.Trim();
                oPRP._Active = ((CheckBox)gvRow.FindControl("chkEditActive")).Checked;
                oPRP._ModifiedBy = Session["CurrentUser"].ToString();
                oDAL.SaveUpdateGeneralMaster("UPDATE", oPRP);
                gvGeneralMaster.EditIndex = -1;
                GetGeneralDetails();
            }
        }
        catch (Exception ex)
        {
            lblErrorMsg.Text = ex.Message.ToString();
            if (!ex.Message.ToString().Contains("Thread was being aborted."))
            {
                //oBL_ClsLog.SaveLog(Convert.ToString(Session["CurrentUser"]).Trim(), "Exception", ex.Message.ToString(), "GROUP MASTER");
                ErrMsg = ex.Message.ToString(); try { string[] arrErr = ex.Message.ToString().Split('\n'); ErrMsg = arrErr[0].ToString().Trim(); }
                catch { } Response.Redirect("Error.aspx?Error=" + ErrMsg.ToString().Trim());
            }
        }
    }
