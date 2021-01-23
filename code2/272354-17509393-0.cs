	Video _SegaVideo;
	Video _IntroVideo;
	public _FrmMain()
	{
		InitializeComponent();
		_SegaVideo = new Video(@"video\SEGA.AVI");
		_SegaVideo.Owner = _VideoPanel;
		_SegaVideo.Play();
		_SegaVideo.Ending += new EventHandler(_SegaVideoEnding);
	  
	}
	private void _SegaVideoEnding(object sender, EventArgs e)
	{
		_IntroVideo = new Video(@"video\INTRO.AVI");
		_IntroVideo.Owner = _VideoPanel;
		_IntroVideo.Play();
	}
