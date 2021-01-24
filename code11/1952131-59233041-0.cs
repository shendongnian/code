    private void searchTextBox_TextChanged(object sender, EventArgs e)
    {
        if(string.IsNullOrEmpty(searchTextBox.Text))
        {
            doctorsCheckedListBox.DataSource = doctors;
        }
        else
        {
            var filteredDoctors = 
                new BindingList<CheckedListBoxItem<Doctor>>
                (doctors.Where(x => x.DataBoundItem.Name.StartsWith(searchTextBox.Text))
                .ToList());
            doctorsCheckedListBox.DataSource = filteredDoctors;
        }
        for (var i = 0; i < doctorsCheckedListBox.Items.Count; i++)
        {
            doctorsCheckedListBox.SetItemCheckState(i,
                ((CheckedListBoxItem<Doctor>)doctorsCheckedListBox.Items[i]).CheckState);
        }
    }
