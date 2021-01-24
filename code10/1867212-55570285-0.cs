            //Adding a test item
            TreeViewItem tvi = new TreeViewItem();
            tvi.Header = "ImAStandardTreeViewItem";
            //adding a ComboBox
            ComboBox cb = new ComboBox();
            ComboBoxItem cbi = new ComboBoxItem();
            cbi.Content = "WuhuImInAComboBox";
            cb.Items.Add(cbi);
            //add them to TreeView
            this.tree.Items.Add(tvi);
            this.tree.Items.Add(cb);
