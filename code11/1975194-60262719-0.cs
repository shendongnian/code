string sqlConnectionString = "//secret";
            using (SqlConnection conn = new SqlConnection(sqlConnectionString))
            {
                try
                {
                    conn.Open();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
                Debug.WriteLine("Connection opened");
                var table = new DataTable();
                // read the table structure from the database
                using (var adapter = new SqlDataAdapter($"SELECT TOP 0 * FROM dbo.TrafficSpeedBands", conn))
                {
                    adapter.Fill(table);
                };
                
                Debug.WriteLine("Filling in rows");
                for (var i = 0; i < test.Count; i++)
                {
                    var row = table.NewRow();
                    row["LinkID"] = test[i].LinkID;
                    row["RoadName"] = test[i].RoadName;
                    row["RoadCategory"] = test[i].RoadCategory;
                    row["SpeedBand"] = test[i].SpeedBand;
                    row["MinimumSpeed"] = test[i].MinimumSpeed;
                    row["MaximumSpeed"] = test[i].MaximumSpeed;
                    row["StartLatitude"] = test[i].StartLatitude;
                    row["StartLongitude"] = test[i].StartLongitude;
                    row["EndLatitude"] = test[i].EndLatitude;
                    row["EndLongitude"] = test[i].EndLongitude;
                    row["Distance"] = test[i].Distance;
                    
                    table.Rows.Add(row);
                }
                using (var sqlBulk = new SqlBulkCopy(conn))
                {
                    Debug.WriteLine("Ready to load live");
                    sqlBulk.DestinationTableName = "dbo.TrafficSpeedBands";
                    try
                    {
                        // Write from the source to the destination.
                        sqlBulk.WriteToServer(table);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }                                        
                    Debug.WriteLine("Done");
                }
                conn.Close();
            }
