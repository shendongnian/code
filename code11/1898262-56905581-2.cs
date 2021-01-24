    checkedListBox1.Items.Clear   
    checkedListBox1.Items.AddRange(dataGridView1.Columns.Cast<DataGridViewColumn>()
                                                        .Select(x => x.Name)
                                                        .ToArray());
    for (int i = 0; i < checkedListBox1.Items.Count; i++)
    {
        checkedListBox1.SetItemChecked(i, true);
    }
    checkedListBox1.CheckOnClick = true;
