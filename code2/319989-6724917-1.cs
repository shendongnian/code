    private void cbSlotsSelectedIndexChanged(object sender, EventArgs e)
    {
        ComboBox cBox = (ComboBox) sender;
        int tag = (int)cBox.Tag;
        var item = ConfigClass.Slots[tag.ToString()][cBox.SelectedIndex];
        ConfigClass.Slots[tag.ToString()].Insert(tag, item);
        ConfigClass.Slots[tag.ToString()].RemoveAt(item.SelectedIndex + 1);
    }
