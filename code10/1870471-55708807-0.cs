    lvproducten.View = View.Details;
    lvproducten.Columns.Add("ID", 100, HorizontalAlignment.Left);
    lvproducten.Columns.Add("Productnaam", 150, HorizontalAlignment.Left);
    while (rdr.Read())
                {
                    //lvproducten.Items.Add(rdr.GetString("ID"));
                    //lvproducten.Items.Add(rdr.GetString("Productnaam"));
                    string[] str = new string[1];
                    ListViewItem itm;
                    str[0] = rdr.GetString("ID");
                    str[1] = rdr.GetString("Productnaam")
                    itm = new ListViewItem(str);
                    lvproducten.Items.Add(itm);
                }
