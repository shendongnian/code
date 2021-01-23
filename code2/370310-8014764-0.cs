     DataGridComboBoxColumn col = new DataGridComboBoxColumn();
            col.Header = "Name";
            col.DisplayMemberPath = "Name"; 
            col.SelectedValueBinding = new Binding("Name");
            col.ItemsSource = simacc;
            col.TextBinding = new Binding("Name");
            col.CanUserSort = false;
            dataGrid1.Columns.Add(col);
