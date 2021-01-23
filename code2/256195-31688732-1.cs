			ddlFromBudget.Items.Clear();
			ListItem newItem = new ListItem();
			newItem.Text = "Not Set";
			newItem.Value = "0";
			ddlFromBudget.Items.Add(newItem);
			if (ddlB1.SelectedValue.ToString() != "0")
			{
				newItem = new ListItem();
				newItem.Text = ddlB1.SelectedItem.ToString();
				newItem.Value = "1";
				ddlFromBudget.Items.Add(newItem);
			}
