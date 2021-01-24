    using (OpenFileDialog ofd = new OpenFileDialog())
    {        
        ofd.Multiselect = true;
        ofd.Filter = "Файлы изображений (*.jpg, )|*.jpg";
        ofd.Title = "Выберите файлы изображений";
        if (ofd.ShowDialog() != DialogResult.OK)
            return;
        ListPathFoto.Clear();
        foreach (string f in ofd.FileNames)
        {
            ListPathFoto.Add(f);
        }
    }
    imageList1.ImageSize = new Size(32, 32);
    imageList1.Images.Clear();
    foreach (var oneFilePath in ListPathFoto)
    {
        var image = Image.FromFile(oneFilePath);
        Image thumb = image.GetThumbnailImage(32, 32, () => false, IntPtr.Zero);
        imageList1.Images.Add(thumb);
        image.Dispose(); // important for clear memory
    }
    
    listView1.Clear();
    listView1.View = View.LargeIcon;            
    listView1.LargeImageList = imageList1;
    for (int j = 0; j < imageList1.Images.Count; j++)
    {
        ListViewItem item = new ListViewItem
        {
            ImageIndex = j
        };
        listView1.Items.Add(item);                
    }
