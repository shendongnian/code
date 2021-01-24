    private void button1_Click(object sender, EventArgs e)
        {
            int g = 0;
            int h = 3;
            var parentTabControl = new TabControl { Dock = DockStyle.Fill };
            while (g < h) 
            {
                g++;
                parentTabControl.TabPages.Add("A" + g.ToString());
                var page = parentTabControl.TabPages[g-1]; 
                var childTabControl = new TabControl { Dock = DockStyle.Fill };
                childTabControl.TabPages.Add("B" + g.ToString());
                page.Controls.Add(childTabControl);
            }
            this.Controls.Add(parentTabControl);
        }
