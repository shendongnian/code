    using (var ctx = new DataClasses1DataContext())
    {
        string[] names = {"BASE_TABLE", "BASE TABLE"};
        var qry = (from table in ctx.Tables
                   where names.Contains(table.TableName)
                   join column in ctx.Columns on table.TableName equals column.TableName
                   orderby table.TableName, column.ColumnName
                   select new { table.TableName, column.ColumnName }).ToList();
        foreach (var pair in qry.GroupBy(pair => pair.TableName))
        {
            TreeNode tableNode = new TreeNode(pair.Key);
            myTree.Nodes.Add(tableNode);
            foreach (var col in pair)
            {
                tableNode.ChildNodes.Add(new TreeNode(col.ColumnName));
            }
        }
    }
