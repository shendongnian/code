    private void searchBox_TextChanged(object sender, EventArgs e)
    {
    	if (gridUsers.Rows.Count > 0)
    	{
    		foreach (UltraGridRow row in gridUsers.Rows)
    		{
    			if (Regex.IsMatch(row.Cells[1].Value.ToString(), searchBox.Text, RegexOptions.IgnoreCase))
    			{
    				gridUsers.Rows[indexCounter].Hidden = false;
    			}
    			else
    			{
    				gridUsers.Rows[indexCounter].Hidden = true;
    			}
    		}
    	}
    }
