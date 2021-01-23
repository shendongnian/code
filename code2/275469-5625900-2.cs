        private void cleanFiles_DoWork(object sender, DoWorkEventArgs e)
        {
            if (listView1.CheckedItems.Count != 0)
            {
                // If so, loop through all checked files and delete.
                for (int x = 0; x <= listView1.CheckedItems.Count - 1; x++)
                {
                    string tempDirectory = Path.GetTempPath();
                    foreach (ListViewItem item in listView1.CheckedItems)
                    {
                        string fileName = item.Text;
                        string filePath = Path.Combine(tempDirectory, fileName);
                        try
                        {
                            File.Delete(filePath);
                        }
                        catch (Exception)
                        {
                            //ignore files being in use
                        }
                    }
                }
                PaintListViewAndSetLabel();
            }
            else
            {
                ShowMessageBox();
            }
        }
        private void ShowMessageBox()
        {
            if(InvokeRequired)
            {
                this.Invoke(new Action(ShowMessageBox), new object[0]);
                return;
            }
            MessageBox.Show("Please put a check by the files you want to delete");
        }
        private void PaintListViewAndSetLabel()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(PaintListViewAndSetLabel),new object[0]);
                return;
            }
            PaintListView(tFile);
            MessageBox.Show("Files removed");
            toolStripStatusLabel1.Text = ("Ready");
        }
