		CheckBox checkSource;
		TextBox textAffecting;
		
		checkSource = e.Row.FindControl("cbSource") as CheckBox;
		textAffecting = e.Row.FindControl("tbAffecting") as TextBox;
		
		if(checkSource != null)
		{
			textAffecting.Enabled = checkSource.Checked;
		}
		
		checkSource.Attributes.Add("onclick", "ManageControlEnabling('" + checkSource.ClientID + "', '" + textAffecting.ClientID + "', true);");
