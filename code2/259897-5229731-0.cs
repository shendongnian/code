    treeView1.Nodes.Clear();
    
    Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
    
    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
    	string city = (string)row.Cells[0].Value;
    	string subCity = (string)row.Cells[1].Value;
    
    	if (city == null || subCity == null)
    		continue;
    
    	if (dict.ContainsKey(city))
    	{
    		dict[city].Add(subCity);
    	}
    	else
    	{
    		dict.Add(city, new List<string>());
    		dict[city].Add(subCity);
    	}
    }
    
    foreach (var kvp in dict)
    {
    	TreeNode parent = new TreeNode(kvp.Key);
    
    	foreach (string subCity in kvp.Value)
    	{
    		parent.Nodes.Add(subCity);
    	}
    
    	treeView1.Nodes.Add(parent);
    }
