        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in this.menuStrip1.Items.Cast<ToolStripMenuItem>())
            {
                GetCheckMenuItemText(item);
            }
        }
        private void GetCheckMenuItemText(ToolStripMenuItem item)
        {
            if (item.HasDropDownItems)
            {
                foreach (var subItem in item.DropDownItems.Cast<ToolStripMenuItem>())
                {
                    GetCheckMenuItemText(subItem);
                }
            }
            else
            {
                if (item.CheckOnClick)
                    Debug.WriteLine(item.Text);
            }
        }
