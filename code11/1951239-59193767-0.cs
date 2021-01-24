    if (listBox1.SelectedIndex >= 0)
    {
        listBox3.Items.RemoveAt(listBox1.SelectedIndex);
        listBox2.Items.RemoveAt(listBox1.SelectedIndex);
        listBox1.Items.RemoveAt(listBox1.SelectedIndex);
    }
