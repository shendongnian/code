    private void FindAllOfMyString(string searchString) {
        for (int i = 0; i < listBox1.Items.Count; i++) {
            if (listBox1.Items[i].ToString().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0) {
                listBox1.SetSelected(i, true);
            } else {
                // Do this if you want to select in the ListBox only the results of the latest search.
                listBox1.SetSelected(i, false);
            }
        }
    }
