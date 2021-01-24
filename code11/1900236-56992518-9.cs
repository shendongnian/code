    TextFormatFlags comboTRFlags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter;
    private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
        if (e.Index < 0) return;
        var combo = sender as ComboBox;
        bool isCheckBoxChecked = comboCheckBoxes[e.Index].Checked;
        if (isCheckBoxChecked) {
            e.DrawBackground();
        }
        else {
            using (var brush = new SolidBrush(combo.BackColor)) {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }
        }
        string itemText = combo.GetItemText(combo.Items[e.Index]);
        Color textColor = isCheckBoxChecked ? e.ForeColor : SystemColors.GrayText;
        TextRenderer.DrawText(e.Graphics, itemText, combo.Font, e.Bounds, textColor, comboTRFlags);
    }
    private void comboBox1_MeasureItem(object sender, MeasureItemEventArgs e) 
        => e.ItemHeight = comboBox1.Font.Height + 4;
    private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
    {
        if (!comboCheckBoxes[comboBox1.SelectedIndex].Checked) {
            comboBox1.SelectedIndex = -1;
            return;
        }
    }
