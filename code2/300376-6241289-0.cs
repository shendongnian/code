    new System.Threading.Thread(
        () =>
        {
            var c = new System.Windows.Media.MediaPlayer();
            c.Open(new System.Uri(@"C:\windows\media\tada.wav"));
            c.Play();
        }).Start();
    System.Threading.Thread.Sleep(500);
    new System.Threading.Thread(
        () =>
        {
            var c = new System.Windows.Media.MediaPlayer();
            c.Open(new System.Uri(@"C:\windows\media\tada.wav"));
            c.Play();
        }).Start();
