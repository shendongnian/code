                    string query = "SELECT * FROM company where company_name Like '" + textBoxSearchCompany.Text + "%'";
                    listViewCompany.Items.Clear();
                    DBConn db = new DBConn();
                    DataTable tbl = db.retrieveRecord(query);
                    int x = 0;
                    foreach (DataRow row in tbl.Rows)
                    {
                        ListViewItem lv = new ListViewItem(row[1].ToString());
                        lv.SubItems.Add(row[2].ToString());
                        lv.SubItems.Add(row[28].ToString());
                        lv.SubItems.Add(row[29].ToString());
                        listViewCompany.Items.Add(lv);
                    }
