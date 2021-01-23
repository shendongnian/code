    // Check for new orders.
                MySql.Data.MySqlClient.MySqlConnection msc = new MySql.Data.MySqlClient.MySqlConnection(cs);
                try
                {
    
    
    
                    this.Cursor = Cursors.WaitCursor;
    
                    msc.Open();
    
                    // Check for orders now.
                    string st = "SELECT DISTINCT(sessionid), firstname, lastname, email, streetaddress, suburb, postcode, state, phone, company FROM mysql_9269_dbase.order";
                    MySql.Data.MySqlClient.MySqlCommand cd = new MySql.Data.MySqlClient.MySqlCommand(st, msc);
                    MySql.Data.MySqlClient.MySqlDataReader msdr = cd.ExecuteReader();
    
                    while (msdr.Read())
                    {
                        if (thelist.Items.Count == 0)
                        {
                            ListViewItem LItem = new ListViewItem(msdr[0].ToString());
                            ListViewItem.ListViewSubItemCollection SubItems = new ListViewItem.ListViewSubItemCollection(LItem);
    
                            SubItems.Add(msdr[1].ToString());
                            SubItems.Add(msdr[2].ToString());
                            SubItems.Add(msdr[3].ToString());
                            SubItems.Add(msdr[4].ToString() + " " + msdr[5].ToString() + " " + msdr[6].ToString() + " " + msdr[7]);
                            SubItems.Add(msdr[8].ToString());
                            SubItems.Add(msdr[9].ToString());
    
                            thelist.Items.Add(LItem);
    
                            thelist.Update();
                        }
                        else
                        {
                            var found = false; foreach (var item in thelist.Items)
                            {
                                if (item.ToString().Contains(msdr[0].ToString()))
                                    found = true;
                            }
                            if (thelist.Items.Count == 0 || !found)
                            {
                                ListViewItem LItem = new ListViewItem(msdr[0].ToString());
                                ListViewItem.ListViewSubItemCollection SubItems = new ListViewItem.ListViewSubItemCollection(LItem);
    
                                SubItems.Add(msdr[1].ToString());
                                SubItems.Add(msdr[2].ToString());
                                SubItems.Add(msdr[3].ToString());
                                SubItems.Add(msdr[4].ToString() + " " + msdr[5].ToString() + " " + msdr[6].ToString() + " " + msdr[7]);
                                SubItems.Add(msdr[8].ToString());
                                SubItems.Add(msdr[9].ToString());
    
                                thelist.Items.Add(LItem);
    
                                thelist.Update();
                            }
                        }
                    }
                }
                catch (Exception en)
                {
                    MessageBox.Show(en.Message, "Uh, oohhhhhh!");
                }
                msc.Close();
    
                this.Cursor = Cursors.Arrow;
