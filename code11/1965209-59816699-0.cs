     string insertStatment = "INSERT INTO xxx.BTH_V_LOCATION (PLANTCODE, LOCATIONCODE, LOCATIONNAME, LOCATIONSTATUS, DEPARTMENTCODE, DEPARTMENTNAME) VALUES (?,?,?,?,?,?)";
            List<Foo> dataList = GetData();
            if (dataList.Count > 0)
            {
                using (OleDbConnection con2 = new OleDbConnection(connectionString))  //OleDbConnection
                {
                    using (OleDbCommand cmd2 = new OleDbCommand(insertStatment, con2))  //OleDbCommand
                        {
                            con2.Open();
                            cmd2.Parameters.Clear();
                            foreach (var items in dataList)
                            {
                                cmd2.Parameters.Add("?", OleDbType.VarChar).Value = items.PLANTCODE;
                                cmd2.Parameters.Add("?", OleDbType.VarChar).Value = items.LOCATIONCODE;
                                cmd2.Parameters.Add("?", OleDbType.VarChar).Value = items.LOCATIONNAME;
                                cmd2.Parameters.Add("?", OleDbType.VarChar).Value = items.LOCATIONSTATUS;
                                cmd2.Parameters.Add("?", OleDbType.VarChar).Value = items.DEPARTMENTCODE;
                                cmd2.Parameters.Add("?", OleDbType.VarChar).Value = items.DEPARTMENTNAME;
                                //cmd2.ExecuteNonQuery();
                                //cmd2.Parameters.Clear();
                             }
                         cmd2.ExecuteNonQuery();
                         //cmd2.Parameters.Clear();
                        }
                   } 
               }
