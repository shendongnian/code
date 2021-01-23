     for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                for (int j = 0; j < dt.Columns.Count; j++)
                                {
                                    if (string.IsNullOrEmpty(dt.Rows[i][j].ToString()))
                                    {
                                       
                                        dt.Rows[i][j] = "0";
                                    }
                                }
                            }
