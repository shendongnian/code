    private void Button_Click(object sender, RoutedEventArgs e)
    {
        WebClient wc = new WebClient();
        wc.DownloadDataAsync(new Uri("https://www.dropbox.com/s/l3maq8j3yzciedw/App%20in%205%20minutes.PNG?raw=1"));
        wc.DownloadDataCompleted += Wc_DownloadDataCompleted;
    }
    private void Wc_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
    {
        MemoryStream stream = new MemoryStream((byte[])e.Result);
        System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(stream);
        bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
        stream.Position = 0;
        BitmapImage bi = new BitmapImage();
        bi.BeginInit();
        bi.StreamSource = stream;
        bi.EndInit();
        image1.Source = bi;
    }
