    private void Form1_Load(object sender, EventArgs e)
        {
            TabPage tab = tabControl1.TabPages[0];
            var newTab = new formTab();
            newTab.TopLevel = false;
            newTab.Dock = DockStyle.Fill;
            newTab.Show();
            newTab.Visible = true;
            tab.Controls.Add(newTab);
        }
    private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            var tabAdd = tabControl1.TabCount - 1;
            if (tabControl1.SelectedIndex == tabAdd)
            {
                //create a new tabpage
                var t = new TabPage();
                //create a new formTab with webControl in it
                var newTab = new formTab();
                //show the new formTab
                newTab.Show();
                newTab.TopLevel = false;
                newTab.Dock = DockStyle.Fill;
                newTab.Visible = true;
                //add formTab as new control in the tabpage just created
                t.Controls.Add(newTab);
                //insert the new created tab into tab control and before tabLoc
                tabControl1.TabPages.Insert(tabAdd, t);
                //select the new created tab
                var newCreatedTab = tabControl1.TabCount - 2;
                tabControl1.SelectedIndex = newCreatedTab;
            }
        }
