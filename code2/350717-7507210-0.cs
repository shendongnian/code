    private string[] testData = new string[] { "Alpha", "Beta", "Gamma", "Delta", "Eta", "Theta", "Zeta", "Iota" };
    protected void TestListBoxOnLoad(object sender, EventArgs e)
    {
    	foreach (var data in testData)
    	{
    		ListItem item = new ListItem()
    		{
    			Text = data
    		};
    
    		if (data.Length < 5)
    		{
    			item.Attributes.Add("class", "aaStyle");
    		}
    		else
    		{
    			item.Attributes.Add("class", "bbStyle");
    		}
    
    		testListBox.Items.Add(item);
    	}
    }
