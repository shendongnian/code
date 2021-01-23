    private void FindAllOfMyString(string searchString)
        {
            // Set the SelectionMode property of the ListBox to select multiple items.
            ListBox.SelectionMode = SelectionMode.MultiExtended;
            // Set our intial index variable to -1.
            int x = -1;
            // If the search string is empty exit.
            if (searchString.Length != 0)
            {
                // Loop through and find each item that matches the search string.
                do
                {
                    // Retrieve the item based on the previous index found. Starts with -1 which searches start.
                    x = ListBox.FindString(searchString, x);
                    // If no item is found that matches exit.
                    if (x != -1)
                    {
                        // Since the FindString loops infinitely, determine if we found first item again and exit.
                        if (ListBox.SelectedIndices.Count > 0)
                        {
                            if (x == ListBox.SelectedIndices[0])
                                return;
                        }
                        // Select the item in the ListBox once it is found.
                        ListBox.SetSelected(x, true);
                    }
                } while (x != -1);
            }
        }
    private void Srchbtn_Click(object sender, EventArgs e)
        {
            FindAllOfMyString(SrchBox.Text);
        }
