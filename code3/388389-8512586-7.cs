        private void FilterMenuText_TextChanged(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem menuItem in menuStrip1.Items)
            {
                if (menuItem.DropDownItems.Count > 0)
                {
                    bool matchFound = false;
                    foreach (ToolStripMenuItem childMenuItem in menuItem.DropDownItems)
                    {
                        if (childMenuItem.Text.ToUpper().Contains(FilterMenuText.Text.ToUpper()))
                        {
                            matchFound = true;
                            break;
                        }
                    }
                    menuItem.Visible = matchFound;
                }
            }
        }
