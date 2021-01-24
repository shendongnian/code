    var items = CheckBoxList1.Items
                .Cast<ListItem>()
                .OrderBy(i=>i.Text)
                .ToArray();
            CheckBoxList1.Items.Clear();
            CheckBoxList1.Items.AddRange(items);
