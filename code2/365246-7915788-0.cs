    public bool UpdateDatabase(string SelectStat, string tablename, DataSet dataset)
    {
        try
        {
            MySqlDataAdapter da = new MySqlDataAdapter(SelectStat, _conn);
            MySqlCommandBuilder MYCB = new MySqlCommandBuilder(da);
            DataSet ds = dataset;
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            //Added this
            ITableMapping testing = da.TableMappings.Add(tablename,"Table");
            da.Update(ds, tablename);
            MySqlConnection.ClearAllPools();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    
    }
