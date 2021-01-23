    using System.Linq;
    private void listBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListBox thisListBox = sender as ListBox;
        if (thisListBox == null || thisListBox.SelectedIndex == 0)
        {
            return;
        }
    
        foreach (ListBox loopListBox in this.Controls.OfType<ListBox>().ToList())
        {
            if (thisListBox != loopListBox)
            {
                loopListBox.SelectedIndex = -1;
            }
        }
    }
