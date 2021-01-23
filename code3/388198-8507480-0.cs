    private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string x="";
        foreach(string chk in checkedListBox1.CheckedItems)
        {
            x = x + "Checked Item " + checkedListBox1.Items.IndexOf(chk).ToString() + " = " + chk + "\n";
        }
        MessageBox.Show(x);
    }
