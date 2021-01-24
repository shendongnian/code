        using (SQLiteConnection dbConn = new SQLiteConnection(Tools.SqliteConnString()))
        {
            using (SQLiteCommand command = new SQLiteCommand(sql, dbConn))
            {
                dbConn.Open();
    
                string alertTag;
                int group;
                int line;
                int task;
                string sql;
    
                foreach (DataRow row in data.Rows)
                {
                    alertTag = row["Alert Tag"].ToString();
                    group = Convert.ToInt32(row["Group"]);
                    line = Convert.ToInt32(row["Line"]);
                    task = Convert.ToInt32(row["Task"]);
                    sql = string.Format("insert into alert_tag (alert_tag, layer_group, line, task) values ('{0}','{1}','{2}','{3}')", alertTag, group, line, task);
                    command.ExecuteNonQuery();
                    dbConn.Close();                    
                }                
            }
        }
