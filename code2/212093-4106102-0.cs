    string fbPath = Application.StartupPath;
    string fname = "help.chm";
    string filename = fbPath + @"\" + fname;
    FileInfo fi = new FileInfo(filename);
    if (fi.Exists)
    {
    Help.ShowHelp(this, filename, HelpNavigator.Find, "");
    }
    else
    {
    MessageBox.Show("Help file Is in Progress.. ",MessageBoxButtons.OK, MessageBoxIcon.Information);
    
    }
