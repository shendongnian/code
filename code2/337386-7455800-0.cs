        lstviewcategories.View = View.Details; 
        lstviewcategories.Columns.Add(new ColumnHeader() { Width = lstviewcategories.Width - 20 }); 
        lstviewcategories.HeaderStyle = ColumnHeaderStyle.None; 
        lstviewcategories.Sorting = SortOrder.Ascending; 
        lstviewcategories.Dock = DockStyle.None; 
 
        ListViewGroup categorygroup = new ListViewGroup("Category Types",HorizontalAlignment.Center); 
        lstviewcategories.Groups.Add(categorygroup); 
 
 
        var categorytypes = (from categories in abc.categories 
                             select categories.category_Name).ToList(); 
 
        lstviewcategories.Items.Add(new ListViewItem() { Text = "ALL", Group = categorygroup }); 
        foreach (string item in categorytypes) 
        { 
 
            lstviewcategories.Items.Add(new ListViewItem() { Text = item.ToString(), Group = categorygroup }); 
 
        } 
 
        ListViewGroup pricerangegroup = new ListViewGroup("Price Ranges", HorizontalAlignment.Center); 
        lstviewcategories.Groups.Add(pricerangegroup); 
 
        lstviewcategories.Items.Add(new ListViewItem() { Text = "ALL", Group = pricerangegroup }); 
        lstviewcategories.Items.Add(new ListViewItem() { Text = "0-500", Group = pricerangegroup }); 
        lstviewcategories.Items.Add(new ListViewItem() { Text = "500-1000", Group = pricerangegroup }); 
        lstviewcategories.Items.Add(new ListViewItem() { Text = "1000+", Group = pricera
