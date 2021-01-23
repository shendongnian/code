    toolStrip.KeyDown += (s, e) =>
    {
        if (e.KeyCode == Keys.Delete)
        {
            foreach (var item in toolStrip.Items.OfType<ToolStripMenuItem>())
            {
                if (item.Selected)
                {
                    toolStrip.Items.Remove(item);
                    break;
                }
            }
        }
    };
