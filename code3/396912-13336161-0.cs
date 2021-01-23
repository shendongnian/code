    using (SqlCeConnection C = new SqlCeConnection(DBStr))
                using (Cmd)
                {   //using SqlCeCommand
                    Cmd.Connection = C;
                    C.Open();
                    using (SqlCeDataReader Rdr = Cmd.ExecuteReader())
                    {
                        //Create datatable to hold schema and data seperately
                        //Get schema of our actual table
                        DataTable DTSchema = Rdr.GetSchemaTable();
                        DataTable DT = new DataTable();
                        if (DTSchema != null)
                            if (DTSchema.Rows.Count > 0)
                                for (int i = 0; i < DTSchema.Rows.Count; i++)
                                {
                                    //Create new column for each row in schema table
                                    //Set properties that are causing errors and add it to our datatable
                                    //Rows in schema table are filled with information of columns in our actual table
                                    DataColumn Col = new DataColumn(DTSchema.Rows[i]["ColumnName"].ToString(), (Type)DTSchema.Rows[i]["DataType"]);
                                    Col.AllowDBNull = true;
                                    Col.Unique = false;
                                    Col.AutoIncrement = false;
                                    DT.Columns.Add(Col);
                                }
                        while (Rdr.Read())
                        {
                            //Read data and fill it to our datatable
                            DataRow Row = DT.NewRow();
                            for (int i = 0; i < DT.Columns.Count; i++)
                            {
                                Row[i] = Rdr[i];
                            }
                            DT.Rows.Add(Row);
                        }
                        //This is our datatable filled with data
                        return DT;
                    }
                }
