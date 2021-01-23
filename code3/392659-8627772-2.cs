    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        var itemsToRemove = listBox1.Items.Cast<object>().Where(x => !x.ToString().Contains(textBox1.Text)).ToList();
        foreach(var item in itemsToRemove)
            listBox1.Items.Remove(item);
    }
