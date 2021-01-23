    private int GetDropDownWidth(ComboBox combo)
    {
        object[] items = new object[combo.Items.Count];
        combo.Items.CopyTo(items, 0);
        return items.Select(obj => TextRenderer.MeasureText(combo.GetItemText(obj), combo.Font).Width).Max();
    }
