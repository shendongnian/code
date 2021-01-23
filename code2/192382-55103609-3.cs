        private void SortListBox(ListBox oListBox)
        {
            ListBox oSortedListBox = new ListBox();
            oSortedListBox.DataSource = oListBox.Items.Cast<ListItem>().ToDictionary(i => i.Value, i => i.Text).OrderBy(i => i.Value);
            oSortedListBox.DataValueField = "Key";
            oSortedListBox.DataTextField = "Value";
            oSortedListBox.DataBind();
            oListBox.Items.Clear();
            foreach (ListItem oListItem in oSortedListBox.Items)
            {
                oListBox.Items.Add(oListItem);
            }
        }
