    var p1 = new System.Windows.Media.MediaPlayer();
    p1.Open(new System.Uri(@"C:\windows\media\tada.wav"));
    p1.Play();
    
    // this sleep is here just so you can distinguish the two sounds playing simultaneously
    System.Threading.Thread.Sleep(500);
    
    var p2 = new System.Windows.Media.MediaPlayer();
    p2.Open(new System.Uri(@"C:\windows\media\tada.wav"));
    p2.Play();
