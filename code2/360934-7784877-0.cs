    protected System.Windows.Media.MediaPlayer pl = new MediaPlayer();
    
    public void StartPlayback(){
      pl.Open(new Uri(@"/Path/to/media/file.wav"));
      pl.MediaEnded += PlayNext;
      pl.Play();
      }
    private void PlayNext(object sender, EventArgs e){
      pl.Open(new Uri(@"/Path/to/media/file.wav"));
      pl.Play();
      }
