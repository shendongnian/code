    public void PopulateListBox()
        {
            _checkedListBox.Items.Add(new BackupDir(@"C:\foo\bar\desktop", "Desktop"));
        }
        public void IterateSelectedItems()
        {
            foreach(BackupDir backupDir in _checkedListBox.SelectedItems)
            {
                //.. do stuff ..//
            }
        }
        public class BackupDir
        {
            public string Path { get; set; }
            public string DisplayText { get; set; }
            public BackupDir(string path, string displayText)
            {
                Path = path;
                DisplayText = displayText;
            }
        }
