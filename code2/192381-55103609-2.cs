        private void SortListBox(ListBox oListBox)
        {
            ListBox oSortedListBox = new ListBox();
            oSortedListBox.DataSource = oListBox.Items.Cast<ListItem>().OrderBy(x => x.Text).ToArray();
            oSortedListBox.DataBind();
            oListBox.Items.Clear();
            foreach (ListItem oListItem in oSortedListBox.Items)
            {
                oListBox.Items.Add(oListItem);
            }
        }
