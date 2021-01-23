    List<string> test_ = populate.Directorylist();
    
            foreach (var file_ in test_)
            {
                int len_ = file_.Length;
                string FullFilename_ = file_.Remove(0, 8);
                string filename_ = FullFilename_.Remove(filename_.Length - 4).Trim();    
    
                ToolStripItem subItem = new ToolStripMenuItem(filename_);
                subItem.Tag = FullFilename;
                subItem.Click += new EventHandler(populate.openconfig(file_)); //this is my problem line
                templatesToolStripMenuItem.DropDownItems.Add(subItem); 
