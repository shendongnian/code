    public void SetListBoxTabs(ListBox listBox)
    {
        float tabSize = 4.2f;
        float currTabStop = 0;
        int tabs = listBox.GetItemText(listBox.Items[0]).Split('\t').Length - 1;
        if (tabs == 0) return;
        var tabStops = new List<int>(tabs);
        tabStops.AddRange(Enumerable.Repeat(0, tabs).ToArray());
        using (var g = Graphics.FromHwnd(listBox.Handle))
        {
            float average = GetFontAverageCharSize(g, listBox.Font);
            foreach (var item in listBox.Items)
            {
                string text = listBox.GetItemText(item);
                string[] parts = text.Split('\t');  // Use Substring(IndexOf()) here
                for (int i = 0; i < parts.Length - 1; i++)
                {
                    float width = TextRenderer.MeasureText(g, parts[i], listBox.Font,
                        Size.Empty, TextFormatFlags.LeftAndRightPadding).Width;
                    float tabWidth = (width / average) * tabSize;
                    currTabStop += tabWidth;
                    tabStops[i] = (int)Math.Max(currTabStop, tabStops[i]);
                }
                currTabStop = 0;
            }
        }
        listBox.UseTabStops = true;  // Just in case 1 ...
        listBox.UseCustomTabOffsets = true;
        var offsets = listBox.CustomTabOffsets;
        offsets.Clear(); // Just in case 2 ...
        foreach (int tab in tabStops) { offsets.Add(tab); }
    }
    public float GetFontAverageCharSize(Graphics g, Font font)
    {
        string textMax = new string('M', 100);
        string textMin = new string('i', 100);
        float maxWidth = TextRenderer.MeasureText(g, textMax, listBox1.Font).Width;
        float minWidth = TextRenderer.MeasureText(g, textMin, listBox1.Font).Width;
        return (maxWidth + minWidth) / (2.0f * textMax.Length);
    }
