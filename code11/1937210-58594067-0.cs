private void ButtonAdd_Click(object sender, EventArgs e)
{
    // Add new city to list
    Cities.Add(txtBoxEnterCity.Text);
    listBox1.Items.Clear();
    for(int i=0; i < Cities.Count; i++)
    {
        // Add each city to the ListBox
        listBox1.Items.Add(Cities[i]);
    }
}
