    HashSet<string> ListBoxSource = new HashSet<string>();
    private void button2_Click(object sender, EventArgs e)
    {
        string val = listBox1.Text.Trim();
        // ListBoxSource.Add(val) Return true if val isn't present and perform the adding
        if (ListBoxSource.Add(val))
        {
            // DataSource needs to be a IList or IListSource, hence the conversion to List
            listBox1.DataSource = ListBoxSource.ToList();
        }
        else
        {
            MessageBox.Show("Item is already in list");
        }
    }
