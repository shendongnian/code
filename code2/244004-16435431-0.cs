    private int DropDownWidth(ComboBox myCombo)
    {
        int maxWidth = 0, temp = 0;
        foreach (var obj in myCombo.Items)
        {
            temp = TextRenderer.MeasureText(myCombo.GetItemText(obj), myCombo.Font).Width;
            if (temp > maxWidth)
            {
                maxWidth = temp;
            }
        }
        return maxWidth + SystemInformation.VerticalScrollBarWidth;
    }
