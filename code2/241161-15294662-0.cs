     public static DataTable GetRankedDatatable(DataTable dt)
                {
                    var rankedDt = (from row in dt.AsEnumerable()
                                    orderby row.Field<string>("points")
                                    select row).CopyToDataTable();
                    rankedDt.Columns.Add("rank");
                    int rank = 0;
                    for (int i = 0; i < rankedDt.Rows.Count - 1; i++)
                    {
                        rankedDt.Rows[i]["rank"] = rank;
                        if (rankedDt.Rows[i]["points"].ToString() != rankedDt.Rows[i + 1]["points"].ToString())
                        {
                            rank++;
                        }
                    }
                    rankedDt.Rows[rankedDt.Rows.Count - 1]["rank"] = rank;
                    return rankedDt;
                }
