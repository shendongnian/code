    public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        bool successful = storeDictionary.TryGetValue(mailBoxes.SelectedItem, out Store selectedStore);
        if(!successful)
        {
            return;
        }
        // Access selectedStore here
    }
