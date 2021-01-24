        private delegate void ProjectFileReloadDelegate(string pp);
        private void ProjectFileReload(string projectPath)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ProjectFileReloadDelegate(ProjectFileReload), projectPath);
            }
            else
            {
                //This throws the exception
                //I retrive the anchorMode Info 
                Task.Factory.StartNew(
                           delegate {
                               anchorMode.Checked = ProjectOptions_v000.AnchorMode;
                           }, TaskScheduler.FromCurrentSynchronizationContext()
                       );
            
