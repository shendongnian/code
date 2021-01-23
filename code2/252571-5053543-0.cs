        ElementHost host = new ElementHost();
        System.Windows.Controls.ListBox wpfListBox = new System.Windows.Controls.ListBox();
        for (int i = 0; i < 10; i++)
        {
        wpfListBox.Items.Add("Item " + i.ToString());
        }
        host.Dock = DockStyle.Fill;
        host.Controls.Add(wpfListBox);
        this.panel1.Controls.Add(host);
