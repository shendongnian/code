    // Create the root of the tree.
    LocationNode root = new LocationNode();
    
    using (SqlCommand cmd = new SqlCommand()) {
        cmd.Connection = conn; // your connection object, not shown here.
        cmd.CommandText = "The above query, ordered by [Depth] ascending";
        cmd.CommandType = CommandType.Text;
        using (SqlDataReader rs = cmd.ExecuteReader()) {
            while (rs.Read()) {
                int id = rs.GetInt32(0); // ID column
                var parent = root.Get(id) ?? root;
                parent.Add(new LocationNode {
                    ID = id,
                    LocationID = rs.GetInt32(1),
                    Name = rs.GetString(2)
                });
            }
        }
    }
