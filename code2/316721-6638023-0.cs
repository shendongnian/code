         DataTable tblData = new DataTable();
                  string myStr = string.Empty; 
                        MySQLProcessor.dtTable(pullDataQuery, out tblData);
                        foreach (DataRow columnRow in tblData.Rows)
                        {
                          myStr = string.Join("|",columnRow.ItemArray.Select(p => p.ToString()).ToArray());
                          //do whatever you want
                        }
