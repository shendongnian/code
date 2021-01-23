    private void cbSlots0_SelectedIndexChanged(object sender, EventArgs e)
    {
        int tag = (int)((ComboBox)sender).Tag;
        var item = ConfigClass.Slots[tag.ToString()][cbSlots0.SelectedIndex];
        ConfigClass.Slots[tag.ToString()].Insert(tag, item);
        ConfigClass.Slots[tag.ToString()].RemoveAt(cbSlots0.SelectedIndex + 1);
    }
