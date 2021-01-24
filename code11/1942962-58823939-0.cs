    public async Task CheckItems()
    {
    	foreach (var row in listViewMain.Items.Cast<ListViewItem>())
    	{
    		try
    		{    
    			string html = await Helpers.GetRequestAsync(row.Text);
    
    			if (html.Contains(txtBoxFind.Text))
    			{
    				row.SubItems[3].Text = "YES";
    			}
    			else
    			{
    				row.SubItems[3].Text = "NO";
    			}
    
    		} catch(Exception ex) {
    		}
    	}
    }
