      public void Form_Load(object sender, EventArgs e)
                {
                    DirectoryInfo dir = new DirectoryInfo(@"Path OF Image");
                    foreach (FileInfo file in dir.GetFiles())
                    {
                        try
                        {
                            this.imageLists.Images.Add(Image.FromFile(file.FullName));
                        }
                        catch{
                            Console.WriteLine("This is not an image file");
                        }
                    }
                    this.listViewImage.View = View.LargeIcon;
                    this.imageLists.ImageSize = new Size(50, 50);
                    this.listViewImage.LargeImageList = this.imageLists;
         
                    for (int j = 0; j < this.imageLists.Images.Count; j++)
                    {
                        ListViewItem item = new ListViewItem();
                        item.ImageIndex = j;
                        this.listView1.Items.Add(item);
                    }
                }
