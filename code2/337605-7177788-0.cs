    if (listBox2.SelectedItem == null)
    {
        System.Windows.MessageBox.Show("*Please Select unassigned Wks ");
        return;
    }
    else
    {
        if (listBox2.SelectedIndex > -1)
        {
            Object obj = listBox2.SelectedItem;
            listBox1.Items.Add(obj);
            listBox2.Items.Remove(obj);
        }
    }
