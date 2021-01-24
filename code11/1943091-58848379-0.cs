     foreach (DataRow DataDBRow in RequestDataDB.Rows)
                {
                    string json = new JObject(
                                             RequestDataDB.Columns.Cast<DataColumn>()
                                            .Select(DataDBColumn => new JProperty(DataDBColumn.ColumnName, JToken.FromObject(DataDBRow[DataDBColumn])))
                                            ).ToString(Formatting.None);
                    Console.WriteLine(json);
                    Console.WriteLine();
                    string messageId = await publisher.PublishAsync(json);
                   
                }
                await publisher.ShutdownAsync(TimeSpan.FromSeconds(15));
                //databaseConn.Close();
                Console.ReadLine();
