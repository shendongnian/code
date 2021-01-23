    DropDownList ddlConditions2 = (e.Row.FindControl("ddlConditions") as DropDownList);
                    DataTable dt = _reader.GetDataTableByCommandFromStoredProc("getYourDropdownData");
                    ddlConditions2.DataSource = dt;
                    ddlConditions2.DataTextField = "ConditionName";
                    ddlConditions2.DataValueField = "Id";
                    ddlConditions2.DataBind();
                    ddlConditions2.Items.Insert(0, new ListItem("--Select--", "0"));
