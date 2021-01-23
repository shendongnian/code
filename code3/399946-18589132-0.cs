    public bool doesFieldExist(string table, string field)
        {
            bool ret = false;
            try
            {
                if (!openRouteCon())
                {
                    throw new Exception("Could not open Route DB");
                }
                DataTable tb = new DataTable();
                string sql = "select top 1 * from " + table;
                OleDbDataAdapter da = new OleDbDataAdapter(sql, routedbcon);
                da.Fill(tb);
                if (tb.Columns.IndexOf(field) > -1)
                {
                    ret = true;
                }
                tb.Dispose();
            }
            catch (Exception ex)
            {
                log.Debug("Check for field:" + table + "." + field + ex.Message);
            }
            return ret;
        }
       
        public bool checkAndAddColumn(string t, string f, string typ, string def = null)
        {
            // Update RouteMeta if needed.
            if (!doesFieldExist(t, f))
            {
                string sql;
                if (def == null)
                {
                    sql = String.Format("ALTER TABLE {0} ADD COLUMN {1} {2} ", t, f, typ);
                }
                else
                {
                    sql = String.Format("ALTER TABLE {0} ADD COLUMN {1} {2} DEFAULT {3} ", t, f, typ, def);
                }
                try
                {
                    if (openRouteCon())
                    {
                        OleDbCommand cmd = new OleDbCommand(sql, routedbcon);
                        cmd.ExecuteNonQuery();
                        string msg = "Modified :" + t + " added col " + f;
                        log.Info(msg);
                        if (def != null)
                        {
                            try
                            {
                                cmd.CommandText = String.Format("update {0} set {1} = {2}", t, f, def);
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception e)
                            {
                                log.Error("Could not update column to new default" + t + "-" + f + "-" + e.Message);
                            }
                        }
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    log.Error("Could not alter RouteDB:" + t + " adding col " + f + "-" + ex.Message);
                }
            }
            else
            {
                return true;
            }
            return false;
        }
