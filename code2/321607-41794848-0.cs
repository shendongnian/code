    private void RemoveHighlightFromToolStrip(ToolStrip toolStrip)
            {
                foreach (ToolStripItem item in toolStrip.Items)
                {
                    if (item.Pressed || item.Selected)
                    {
                        item.Visible = false;
                        item.Visible = true;
                    }
                }
            }
