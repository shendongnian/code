    var tv = new TreeView();
    using(var conn = new SqlCeConnection("Data Source=" + connString))
    using(var cmd = new SqlCeCommand(conn,"SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES"))
    {
       conn.Open();
       if(conn.State != ConnectionStatus.Open) return;
       cmd.CommandType=CommandType.Text;
       using(var rdr = cmd.ExecuteReader())
       {
          while(rdr.Read())
          {
             tv.Nodes.Add(new TreeNode(rdr.GetString(0));
          }
       }
    }
