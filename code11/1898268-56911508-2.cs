    //Add the columns to checked list box
    var columns = dataGridView1.Columns.Cast<DataGridViewColumn>()
        .Select(x => new { x.Name, x.HeaderText }).ToList();
    checkedListBox1.DataSource = columns;
    checkedListBox1.ValueMember = "Name";
    checkedListBox1.DisplayMember = "HeaderText";
    //Set initial check state based on columns visibility
    for (int i = 0; i < checkedListBox1.Items.Count; i++)
    {
        dynamic item = checkedListBox1.Items[i];
        checkedListBox1.SetItemChecked(i, dataGridView1.Columns[(string)item.Name].Visible);
    }
    //Hanlde ItemCheck event
    checkedListBox1.ItemCheck += (obj, args) =>
    {
        dynamic item = checkedListBox1.Items[args.Index];
        var visible = args.NewValue == CheckState.Checked ? true : false;
        dataGridView1.Columns[(string)item.Name].Visible = visible;
    };
