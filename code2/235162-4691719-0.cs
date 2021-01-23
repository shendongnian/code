            int result = Timesheet_BI.InsertCompanyInformation(txtCompanyName.Text, txtAddress.Text);
            if (result == -1)
            {
                txtCompanyName.Focus();
                txtCompanyName.Attributes["onfocus"] = "this.select();";
                string jv = "<script>alert('Error Details: Duplicate Entry of Company Name ');</script>";
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alert", jv, false);
                return;
                //Page.ClientScript.RegisterStartupScript(typeof(string), "My Script", "Duplicate Enteries");
            }
               }
        catch (Exception ex)
        {
            throw ex;
        }
