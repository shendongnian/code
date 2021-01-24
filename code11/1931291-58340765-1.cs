    string fileCSV = "file.csv";
    var lines = File.ReadAllLines(fileCSV).Skip(1); //Read Lines and Skip header 
    string conStr = "[Your connection string]"; 
    
    using (NpgsqlConnection conn = new NpgsqlConnection(conStr))
    {
        conn.Open();
        foreach (string line in lines)
        {
            if (!String.IsNullOrWhiteSpace(line))
            {
                string comStr = "select * from chartevents c where c.itemid In (211,220045,618,220210,220277,220050,220052,220180,223900,723,223901,454,184,220739,3655,676,223762,223761,3420,2981,813,220545,225651,4948,828,30006,490)and c.subject_id=@ID;";
                using (NpgsqlCommand cmd = new NpgsqlCommand(comStr, conn))
                {
                    cmd.Parameters.Add(new NpgsqlParameter("@Id", line));
                    using (NpgsqlDataReader r = cmd.ExecuteReader())
                    {
                        using (TextWriter tw = new StreamWriter("ID_" + line + ".csv", false, Encoding.Default))
                        {
                            if (r.Read())
                            {
                                //Write Columns header
                                foreach (DataRow c in r.GetSchemaTable().Rows)
                                {
                                    tw.Write(c[0].ToString() + ";");
                                }
                                tw.Write("\r\n");
                                //Write Rows
                                do
                                {
                                    foreach (DataRow c in r.GetSchemaTable().Rows)
                                    {
                                        string column = c[0].ToString();
                                        object o = r[column];
                                        if (o == null)
                                        {
                                            tw.Write(";");
                                        }
                                        else
                                        {
                                            tw.Write(o.ToString() + ";");
                                        }
                                    }
                                    tw.Write("\r\n");
                                } while (r.Read());
                            }
                        }
                    }
                    //reader is closed
                }
                //cmd is disposed
            }
        }
    }
    //connection is closed
