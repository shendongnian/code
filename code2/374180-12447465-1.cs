    toolStripDropDownButton1.KeyDown += (s, e) =>
    {
        if (e.KeyCode == Keys.Delete)
        {
            foreach (var item in ((ToolStrip)s).Items.OfType<ToolStripMenuItem>())
            {
                if (item.Selected)
                {
                    ((ToolStrip)s).Items.Remove(item);
                    break;
                }
            }
        }
    };
