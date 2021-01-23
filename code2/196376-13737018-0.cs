    private void buttonPlayVideo_Click(object sender, RoutedEventArgs e)
    {
        Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
        dlg.Filter = "All Files|*.*";
        Nullable<bool> result = dlg.ShowDialog();
        if (result == true) {
            MediaPlayer mp = new MediaPlayer();
            mp.Open(new Uri(filename));
            VideoDrawing vd = new VideoDrawing();
            vd.Player = mp;
            vd.Rect = new Rect(0, 0, 960, 540);
            DrawingBrush db = new DrawingBrush(vd);
            canvas.Background = db;
            mp.Play();
        }
    }
