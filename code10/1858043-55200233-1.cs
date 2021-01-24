    private void btnTest_Click(object sender, EventArgs e)
    {
        // Show the first item selected as an example.
        if (listView1.SelectedItems.Count > 0) {
            switch (listView1.SelectedItems[0].Tag) {
                case DirectoryInfo di:
                    MessageBox.Show($"Directory = {di.Name}");
                    break;
                case FileInfo fi:
                    MessageBox.Show($"File = {fi.Name}");
                    break;
                default:
                    break;
            }
        }
    }
