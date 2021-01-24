    private void btnDelete_Click(object sender, EventArgs e)
    {
        var itemIndex = listBox1.SelectedIndex;
        listBox1.Items.RemoveAt(itemIndex);
        listBox2.Items.RemoveAt(itemIndex);
        listBox3.Items.RemoveAt(itemIndex);
    }
