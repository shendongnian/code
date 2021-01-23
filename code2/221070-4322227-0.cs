            var fdlg = new OpenFileDialog();
            fdlg.Multiselect = true;
            fdlg.Title = "Select a file to add... ";
            fdlg.InitialDirectory = "C:\\";
            fdlg.Filter = "All files|*.*";
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                foreach (var files in fdlg.FileNames)
                {
                    try
                    {
                        this.imageList1.Images.Add(Image.FromFile(files));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                this.listView1.View = View.LargeIcon;
                this.imageList1.ImageSize = new Size(32, 32);
                this.listView1.LargeImageList = this.imageList1;
                //or
                //this.listView1.View = View.SmallIcon;
                //this.listView1.SmallImageList = this.imageList1;
               for (int j = 0; j < this.imageList1.Images.Count; j++)
                {
                    ListViewItem item = new ListViewItem();
                    item.ImageIndex = j;
                    this.listView1.Items.Add(item);
                }
            }
