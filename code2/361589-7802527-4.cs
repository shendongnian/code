    [WebMethod, ScriptMethod]
    public RadTreeNodeData[] GetRootNodes(RadTreeNodeData node, object context)
    {
        DataTable productCategories = GetProductCategories(node.Value);
        List<RadTreeNodeData> result = new List<RadTreeNodeData>();
        foreach (DataRow row in productCategories.Rows)
        {
            RadTreeNodeData itemData = new RadTreeNodeData(); 
            itemData.Text = row["Title"].ToString(); 
            itemData.Value = row["CategoryId"].ToString();
            if (Convert.ToInt32(row["ChildrenCount"]) > 0) 
            { 
                itemData.ExpandMode = TreeNodeExpandMode.WebService; 
            }
            result.Add(itemData);
        }
        return result.ToArray();
    }
