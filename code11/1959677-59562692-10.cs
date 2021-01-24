    adp.Fill(dt);
                    foreach (DataRow item in dt.Rows)
                    {
                        var plop = new WhoIsActive
                        {
                            Random = item["Random"].ToString(),
                            XmlCol = item["XmlCol"].ToString(),
                        };
                        results.Add(plop);
                    }
                    dataGridView1.DataSource = results;
