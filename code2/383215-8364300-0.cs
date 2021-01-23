        private void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (_loading)
                e.Cancel = true; 
        }
        bool _loading = false; 
        void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _loading = true;
            // ListView populating
            _loading = false; 
        }
