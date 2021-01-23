        private static void SetToolButtonsChecked(object sender)
        {
            ToolStripButton btn = sender as ToolStripButton;
            ToolStrip strip = btn.GetCurrentParent();
            foreach (ToolStripItem item in strip.Items)
            {
                if (!(item is ToolStripButton)) continue;
                ToolStripButton btnTemp = item as ToolStripButton;
                if (!btnTemp.CheckOnClick) continue;
                btnTemp.Checked = btnTemp.Equals(btn);
            }
        }
