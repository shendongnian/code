    public IList<Group> GetGroup()
            {
                Connection c = new Connection();
                String connectionString = c.ConnectionName;
                OleDbConnection conn = new OleDbConnection(connectionString);
                OleDbCommand mycmd = conn.CreateCommand();
                DataSet dspendingapps = new DataSet();
                dspendingapps.Clear();
    
                mycmd.CommandText = " select g.groupid,g.groupname from tbl_group g order by g.groupname ";
                conn.Open();
    
                OleDbDataAdapter appreader = new OleDbDataAdapter(mycmd);
                appreader.Fill(dspendingapps);
                conn.Close();
    
                IList<Group> g = new List<Group>();
    
                foreach (DataRow drapp in dspendingapps.Tables[0].Rows)
                {
                    Group gg = new Group();
                    gg.GroupId = Convert.ToInt16(drapp["groupid"]);
                    gg.Name = drapp["groupname"].ToString();
                    g.Add(gg);
                    
                }
                return g;
            }
