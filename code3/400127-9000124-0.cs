        /// <summary>
        /// Retrieve a list of available files in the input directory
        /// </summary>
        private void LoadAvaliableFiles()
        {
            try
            {
                this.lv_AvailableFiles.Items.Clear();
                //Pick up files from structure
                //Firstly pick up all files in the target directory
                string[] filesFound = this.m_watcher.GetFiles();
                // Verify that we have some files to display in the list
                if (filesFound != null && filesFound.Length > 0)
                {
                    // The ArrayList will contain PreConversionData objects
                    foreach (string filePath in filesFound)
                    {
                        string fileName = Path.GetFileName(filePath);
                        //create a list view item for the file
                        ListViewItem newFile = new ListViewItem(fileName);
                        newFile.Text = fileName;
                        newFile.ToolTipText = filePath;
                        newFile.Tag = filePath;
                        // Add the new item to the list
                        this.lv_AvailableFiles.Items.Add(newFile);
                    }
                }
                this.lv_AvailableFiles.Refresh();
            }
            catch (Exception ex)
            {
                Log.WriteLine( Category.Warning, "Exception detected populating the available files list", ex);
            }
        }
