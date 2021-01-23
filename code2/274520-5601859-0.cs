    ListViewControl.ItemsSource = ItemsSourceObject;   //your query result 
    GridViewColumn column = new GridViewColumn();
    column.Header = "Name";
    column.DisplayMemberBinding = new Binding("Name");
    GridViewControl.Columns.Add(column);
