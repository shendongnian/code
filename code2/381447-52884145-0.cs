    TabPage currentPage;
    
    private void tabControl1_Selected(object sender, TabControlEventArgs e)
    {
        if (e.TabPage == tabNotAllowed)
        {
            tabControl1.SelectedTab = currentPage;
            MessageBox.Show("You cannot use the tab you selected.");
        }
        else
        {
            currentPage = e.TabPage;
        }
    }
