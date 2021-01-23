     private void MainMenu_Load(object sender, EventArgs e)
            { 
                helpProvider1.HelpNamespace = Application.StartupPath + "\\filename.chm";
                helpProvider1.SetShowHelp(this, true);
           }
    private void HelpText_Click(object sender, EventArgs e)
            {
                Help.ShowHelp(this, helpProvider1.HelpNamespace);
    
            }
