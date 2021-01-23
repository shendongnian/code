    TabPage tabPage;
    
    void button1_Click(object sender, EventArgs e)
    {
        // Check if the tabpage doesn't exist yet:
        if (tabPage == null)
        {
            // Create the tab page:
            tabPage = new TabPage();
            tabPage.Name = "TestNewTab";
            tabPage.Text = "Tab Page";
    
            // Add the new tab page:
            tabControl1.TabPages.Add(tabPage);
        }
    }
