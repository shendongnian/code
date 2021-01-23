        public void PopulateListBox()
        {
            _checkedListBox.Items.Add(new BackupDir(@"C:\foo\bar\desktop", "Desktop"));
        }
        public void IterateSelectedItems()
        {
            foreach(BackupDir backupDir in _checkedListBox.CheckedItems)
                Messagebox.Show(string.format("{0}({1}", backupDir.DisplayText, backupDir.Path));            
        }
        public class BackupDir
        {
            public string Path { get; private set; }
            public string DisplayText { get; private set; }
            public BackupDir(string path, string displayText)
            {
                Path = path;
                DisplayText = displayText;
            }
            public override string ToString()
            {
                return DisplayText;
            }
        }
