    private void PopulateTreeView()
    {
        treeView1.Nodes.Clear();
    
        using (var conn = new SqlCeConnection("Data Source=" + connString))
        using (var cmd = conn.CreateCommand())
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"SELECT T.TABLE_NAME, C.COLUMN_NAME
                                FROM INFORMATION_SCHEMA.TABLES AS T INNER JOIN
                                Information_Schema.Columns AS C ON T.TABLE_NAME = C.TABLE_NAME";
            conn.Open();
            cmd.Connection = conn;
    
            using (var reader = cmd.ExecuteReader())
            {
                string lastTable = null;
                TreeNode tableNode = null;
                while (reader.Read())
                {
                    if (lastTable != reader.GetString(0))
                    {
                        lastTable = reader.GetString(0);
                        tableNode = new TreeNode(lastTable);
                        treeView1.Nodes.Add(tableNode);
                    }
                    tableNode.Nodes.Add(new TreeNode(reader.GetString(1)));
                }
            }
        }
    }
