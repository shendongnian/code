    public void PopulateTree(TreeView t1) {
    
        // Clear any exisiting nodes
        t1.Nodes.Clear();
    
        using (SqlConnection connection = new SqlConnection()) {
            connection.ConnectionString = "((replace this string))";
            connection.Open();
    
            string getLocations = @"
                With hierarchy (id, [location id], name, depth, [path])
                As (
    
                    Select ID, [LocationID], Name, 1 As depth,
                        Cast(Null as varChar(max)) As [path]
                    From dbo.Locations
                    Where ID = [LocationID]
    
                    Union All
    
                    Select child.id, child.[LocationID], child.name,
                        parent.depth + 1 As depth,
                        IsNull(
                            parent.[path] + '/' + Cast(parent.id As varChar(max)),
                            Cast(parent.id As varChar(max))
                        ) As [path]
                    From dbo.Locations As child
                    Inner Join hierarchy As parent
                        On child.[LocationID] = parent.ID
                    Where child.ID != parent.[Location ID])
    
                Select *
                From hierarchy
                Order By [depth] Asc";
    
            using (SqlCommand cmd = new SqlCommand(getLocations, connection)) {
                cmd.CommandType = CommandType.Text;
                using (SqlDataReader rs = cmd.ExecuteReader()) {
                    while (rs.Read()) {
                        // I guess you actually have GUIDs here, huh?
                        int id = rs.GetInt32(0);
                        int locationID = rs.GetInt32(1);
                        TreeNode node = new TreeNode();
                        node.Text = rs.GetString(2);
                        node.Value = id.ToString();
    
                        if (id == locationID) {
                            t1.Nodes.Add(node);
                        } else {
                            t1.FindNode(rs.GetString(4)).ChildNodes.Add(node);
                        }
                    }
                }
            }
        }
    }
