    private void cbSlotsSelectedIndexChanged(object sender, EventArgs e)
    {
        var cb = ((ComboBox)sender);
        var tag = int.Parse(cb.Tag.ToString());
        var item = ConfigClass.Slots[tag.ToString()][cb.SelectedIndex];
        ConfigClass.Slots[tag.ToString()].Insert(tag, item);
        ConfigClass.Slots[tag.ToString()].RemoveAt(cb.SelectedIndex + 1);
    }
