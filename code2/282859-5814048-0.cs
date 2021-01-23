    var box = new CheckedListBox
        {
            Dock = DockStyle.Fill,
            CheckOnClick = true
        };
    box.ItemCheck += (sender, e) =>
        {
            if (e.NewValue == CheckState.Checked && box.CheckedItems.Count == 3)
            {
                e.NewValue = CheckState.Unchecked;
            }
        };
    for (var i = 0; i < 10; i++)
    {
        box.Items.Add("item " + i);
    }
    new Form {Controls = {box}}.ShowDialog();
