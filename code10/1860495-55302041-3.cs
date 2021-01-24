    public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(!mailBoxes.SelectedItem is string selectedString))
            return;
        bool successful = storeDictionary.TryGetValue(selectedString, out Store selectedStore);
        if(!successful)
        {
            return;
        }
        // Access selectedStore here
    }
