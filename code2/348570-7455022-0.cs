    private void einsteinButton_Click(object sender, EventArgs e)
    {
        int item = ComboBox.FindStringExact("Einstein");
        if (item >= 0)
            ComboBox.SelectedItem = item;
    }
