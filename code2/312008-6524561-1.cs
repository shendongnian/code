    List<ListItem> listCollection = new List<ListItem>();
                   listCollection.Add(new ListItem { text = "Manufacturer", value = "1" });
                   listCollection.Add(new ListItem { text = "Dealer", value = "2" });
                   listCollection.Add(new ListItem { text = "Distributor", value = "3" });
                   listCollection.Add(new ListItem { text = "Trader", value = "4" });
                   listCollection.Add(new ListItem { text = "Service Provider", value = "5" });
                   chkListCategory.DataSource = listCollection;
                   chkListCategory.DisplayMember = "Text";//"text"; 
                   chkListCategory.ValueMember = "Value";//"value";
