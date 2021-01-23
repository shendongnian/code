    void wizard1_FinishButtonClick(object sender, CancelEventArgs e)
    {
        MainForm mf = new MainForm();
    
        createTab(mf);
        this.Hide();
    }
    
    void createTab(MainForm mf)
    {
        string name = textBoxX1.Text;
        SuperTabItem tab = mf.ProjectTabControl.CreateTab(name);
    }
