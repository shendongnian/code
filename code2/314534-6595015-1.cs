             StringBuilder fileNames = new StringBuilder();
            ArrayList filePaths = new ArrayList();
            FolderBrowserDialog folder = new FolderBrowserDialog();
            
            folder.ShowDialog();
            int pathLength = folder.SelectedPath.Length;
            foreach (string file in Directory.EnumerateFiles(folder.SelectedPath))
            {
                string fielname = file.ToString().Substring(pathLength + 1);
                string filepath = file.ToString();
                fileNames.AppendLine(fielname);
                filePaths.Add(filepath);
            }
            DataSet[] dsCollection = new DataSet[filePaths.Count];
            int filesImported = 0;
            foreach (object ob in filePaths)
            {
                DataSet temp2 = new DataSet();
                temp2.ReadXml(ob.ToString());
                dsCollection[filesImported] = temp2;
                filesImported++;
            }
            int tablesImported = 0;
            int rowImported = 0;
            foreach (DataSet ds in dsCollection)
            {
               DataSet tempds = new DataSet();
               tempds = ds;
                
                foreach (DataTable table in tempds.Tables)
                {
                    mainDS.Merge(table);
                    foreach (DataRow row in table.Rows)
                    {
                        rowImported++;
                    }
                    tablesImported++;
                }
            }
            MessageBox.Show("Files Imported:" + filesImported.ToString() + "    Tables Imported : " + tablesImported.ToString() + "Tables in DS:" + mainDS.Tables.Count.ToString() + "Rows Imported = " +rowImported.ToString());
            dataGridView1.DataSource = mainDS.Tables[0].DefaultView;
            for (int i = 0; i < mainDS.Tables.Count; i++)
            {
                MessageBox.Show(mainDS.Tables[i].TableName.ToString());
            }
