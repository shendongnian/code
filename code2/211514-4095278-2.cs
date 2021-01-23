    Dictionary<string, List<string>> dict =
        listView.Columns
                .Cast<ColumnHeader>()
                .ToDictionary(
                    c => c.Text,
                    c => listView.Items
                                 .Cast<ListViewItem>()
                                 .Select(i => i.SubItems[col.Index].Text)
                                 .ToList());
