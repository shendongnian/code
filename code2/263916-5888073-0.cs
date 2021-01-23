         using (var folderDlg = new FolderBrowserDialog())
         {
            folderDlg.Description = Resources.SelectBranchFolder;
            folderDlg.ShowNewFolderButton = false;
            folderDlg.RootFolder = Environment.SpecialFolder.MyComputer;
            if (folderDlg.ShowDialog() == DialogResult.OK)
            {
               string workingPath = folderDlg.SelectedPath;
               using (var svnClient = new SvnClient())
               {
                  Uri repo = svnClient.GetUriFromWorkingCopy(workingPath);
                  if (repo != null)
                  {
                     MessageBox.Show("The URI for this folder is " + repo.AbsoluteUri);
                  }
                  else
                  {
                     MessageBox.Show("This is not a working SVN directory.");
                  }
               }
            }
         }
