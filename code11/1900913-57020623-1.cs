            var cnWLLocal = new SQLiteConnection
            {
                ConnectionString = "Data Source=WordLightData.sqlite; Version = 3; DateTimeFormat=CurrentCulture ;"
            };
            const string s = "Select Key, WLIdentity, WLIdentityCode, LastSongDBCheck from LocalInfo";
            using (var cmdLocalInfo = new SQLiteCommand(s, cnWLLocal))
            {
                using (var daLocalInfo = new SQLiteDataAdapter(cmdLocalInfo))
                {
                    using (var dsLocalInfo = new DataSet())
                    {
                        daLocalInfo.Fill(dsLocalInfo, "LocalInfo");    // BTW this works perfectly - data is returned
                        using (var bldLocalInfo = new SQLiteCommandBuilder(daLocalInfo))
                        {
                            dsLocalInfo.Tables["LocalInfo"].Rows[0]["WLIdentity"] = "New value";
                            dsLocalInfo.Tables["LocalInfo"].Rows[0]["WLIdentityCode"] = "New value";
                            dsLocalInfo.Tables["LocalInfo"].Rows[0]["LastSongDBCheck"] = Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"));
                            using (DataTable tableChanges = dsLocalInfo.Tables["LocalInfo"].GetChanges(DataRowState.Modified))
                            {
                                if (tableChanges != null)
                                {
                                    daLocalInfo.UpdateCommand = bldLocalInfo.GetUpdateCommand();
                                    int iRowsUpdated = daLocalInfo.Update(tableChanges);
                                }
                            }
                        }
                    }
                }
            }
