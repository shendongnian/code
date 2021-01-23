        private ArrayList GetFilePaths()
        {
            ArrayList filePaths = new ArrayList();
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.ShowDialog();
            foreach (string filePath in Directory.EnumerateFiles(folder.SelectedPath))
            {
                filePaths.Add(filePath.ToString());
            }
            return filePaths;
        }
        private void ImportXmls(ArrayList filePaths)
        {
            DataSet[] tempDSCollection = new DataSet[filePaths.Count];
            int impFiles = 0;
            foreach (object ob in filePaths)
            {
                DataSet impDS = new DataSet();
                impDS.ReadXml(ob.ToString());
                tempDSCollection[impFiles] = impDS;
                impFiles++;
            }
            foreach (DataSet aDS in tempDSCollection)
            {
                foreach (DataTable table in aDS.Tables)
                {
                    mainDS.Merge(table);
                }
            } 
        }
