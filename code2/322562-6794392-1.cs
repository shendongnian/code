    private void removeEndingsButton_Click(object sender, EventArgs e)
    {
        string[] items;
        System.Windows.Forms.ListBox.ObjectCollection contents = placementOneListBox.Items;
        foreach (string str in contents)
        {
           string remove = str.Split(' ')[5];
           List<string> list = str.Split(' ').ToList();
           list.Remove(remove);           
           placementOneListBox.Items.Equals(list.ToArray());
        }
    }
