    var box = new CheckedListBox
        {
            Dock = DockStyle.Fill,
            CheckOnClick = true
        };
    box.ItemCheck += (sender, e) =>
        {
            // is the item being checked when 3 are already checked?
            if (e.NewValue == CheckState.Checked && box.CheckedItems.Count == 3)
            {
                // block the change
                e.NewValue = CheckState.Unchecked;
            }
        };
    for (var i = 0; i < 10; i++)
    {
        box.Items.Add("item " + i);
    }
    new Form {Controls = {box}}.ShowDialog();
