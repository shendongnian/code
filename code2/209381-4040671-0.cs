    private void Window_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
            {
                string[] droppedFilePaths = e.Data.GetData(DataFormats.FileDrop, true) as string[];
                foreach (var path in droppedFilePaths)
                {          
                    string location = null;
                    int pxWidth = 0, pxHeight = 0;
                    FileInfo fi = new FileInfo(path);
                    //fi.Length  //File size
                    //fi.DirectoryName //Directory
                    using (var fs = fi.OpenRead())
                    {
                        try
                        {
                            var bmpFrame = BitmapFrame.Create(fs);
                            var m = bmpFrame.Metadata as BitmapMetadata;
                            if (m != null)
                                location = m.Location;
                            pxWidth = bmpFrame.PixelWidth;
                            pxHeight = bmpFrame.PixelHeight;
                        }
                        catch
                        {
                            //File isn't image
                        }
                    }
                    this.fileList.Items.Add(string.Format("({0}x{1}), location: {2}", pxWidth, pxHeight, location));
                }
            }
        }
