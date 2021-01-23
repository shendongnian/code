    using (var conn = new SqlCeConnection(connectionString))
    using (var cmd = conn.CreateCommand())
    {
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = @"
    SELECT T.TABLE_NAME, C.COLUMN_NAME
    FROM INFORMATION_SCHEMA.TABLES T
    INNER JOIN INFORMATION_SCHEMA.COLUMNS C
    ON T.TABLE_NAME= C.TABLE_NAME
    WHERE T.TABLE_NAME IN('BASE_TABLE', 'BASE TABLE')
    ORDER BY 1, C.ORDINAL_POSITION";
        conn.Open();
        cmd.Connection = conn;
        using (var reader = cmd.ExecuteReader())
        {
            string lastTable = null;
            TreeNode tableNode = null;
            while (reader.Read()) { 
                if (lastTable != reader.GetString(0)) {
                    lastTable = reader.GetString(0);
                    tableNode = new TreeNode(lastTable);
                    myTree.Nodes.Add(tableNode);
                }
                tableNode.ChildNodes.Add(new TreeNode(reader.GetString(1)));
            }
        }
    }
