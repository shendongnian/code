    private void bFolder_Click(object sender, EventArgs e)
    {
        TreeNode currentNode = tvSource.SelectedNode;
        SPObjectData objectData = (SPObjectData)currentNode.Tag;
        using (SPWeb TopLevelWeb = objectData.Web)
        {
            dwnEachWeb(TopLevelWeb, TopLevelWeb.Title, tbDirectory.Text);
        }
    }
    private void dwnEachWeb(SPWeb TopLevelWeb, string FolderName, string CurrentDirectory)
        {
            if (TopLevelWeb != null)
            {
                if (TopLevelWeb.Webs != null)
                {
                    CurrentDirectory = CurrentDirectory + "//" + TopLevelWeb.Title;
                    CreateFolder(CurrentDirectory);
                    foreach (SPWeb ChildWeb in TopLevelWeb.Webs)
                    {
                        
                        dwnEachWeb(ChildWeb, ChildWeb.Title, CurrentDirectory);
                        ChildWeb.Dispose();
                    }
                    dwnEachList(TopLevelWeb, CurrentDirectory);
                    //dwnEachList(TopLevelWeb, FolderName, CurrentDirectory);
                }
            }
        }
        private void dwnEachList(SPWeb oWeb, string CurrentDirectory)
        {
            foreach (SPList oList in oWeb.Lists)
            {
                if (oList is SPDocumentLibrary && !oList.Hidden)
                {
                    dwnEachFile(oList.RootFolder, CurrentDirectory);
                }
            }
        }
        private void dwnEachFile(SPFolder oFolder, string CurrentDirectory)
        {
            if (oFolder.Files.Count != 0)
            {
                CurrentDirectory = CurrentDirectory + "//" + oFolder.Name;
                CreateFolder(CurrentDirectory);
                foreach (SPFile ofile in oFolder.Files)
                {
                    if (CreateDirectoryStructure(CurrentDirectory, ofile.Url))
                    {
                        var filepath = System.IO.Path.Combine(CurrentDirectory, ofile.Url);
                        byte[] binFile = ofile.OpenBinary();
                        System.IO.FileStream fstream = System.IO.File.Create(filepath);
                        fstream.Write(binFile, 0, binFile.Length);
                        fstream.Close();
                    }
                }
            }
        }
        //creating directory where files will be download        
        private bool CreateDirectoryStructure(string baseFolder, string filepath)
        {
            if (!Directory.Exists(baseFolder)) return false;
            var paths = filepath.Split('/');
            for (var i = 0; i < paths.Length - 1; i++)
            {
                baseFolder = System.IO.Path.Combine(baseFolder, paths[i]);
                Directory.CreateDirectory(baseFolder);
            }
            return true;
        }
        //creating folders
        private bool CreateFolder(string CurrentDirectory)
        {
            if (!Directory.Exists(CurrentDirectory))
            {
                Directory.CreateDirectory(CurrentDirectory);
            }
            return true;
        }
