    foreach (ColumnDefinition cd in this.ColumnDefinitions)
    {
        ColumnHeader ch = new ColumnHeader();
        ch.Name = cd.Name;
        ch.Tag = cd;
        ch.Text = cd.Text;
     
        this.extendedListView.Columns.Add(ch);
    }
