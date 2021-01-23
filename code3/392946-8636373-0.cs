     DataTable GetTable() {
                //You can store a DataTable in the session state
                DataTable table = Session["Table"] as DataTable;
                if (table == null) {
                    table = new DataTable();
                    table.Columns.Add("id", typeof(int));
                    table.Columns.Add("data", typeof(String));
                    for (int n = 0; n < 100; n++) {
                        table.Rows.Add(n, "row" + n.ToString());
                    }
                    Session["Table"] = table;
                }
        
                //Otherwise you have to create a DataTable instance on every request:
                //DataTable table = new DataTable();
                //table.Columns.Add("id", typeof(int));
                //table.Columns.Add("data", typeof(String));
                //for(int n = 0; n < 100; n++) {
                //    table.Rows.Add(n, "row" + n.ToString());
                //}
        
                return table;
            }
