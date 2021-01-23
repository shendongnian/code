    private void removeEndingsButton_Click(object sender, EventArgs e)
    {
        string[] items;
        System.Windows.Forms.ListBox.ObjectCollection contents = placementOneListBox.Items;
        foreach (string str in contents)
        {
           
           List<string> list = str.Split(' ').ToList();
           if(list.Count == 6)
           {
               string remove = list[5];
               list.Remove(remove);           
               placementOneListBox.Items.Equals(list.ToArray());
           }
        }
    }
