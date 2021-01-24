    //Create a new MediaPlayer object
    private static readonly MediaPlayer _backgroundMusic = new MediaPlayer();
    
    public static void StartBackgroundMusic(){
        //Open the temp WAV file saved in the temp location and called "backgroundmusic.wav"
        _backgroundMusic.Open(new Uri(Path.Combine(Path.GetTempPath(), "backgroundmusic.wav")));
        //Add an event handler for when the media has ended, this way
        //the music can be played on a loop
        _backgroundMusic.MediaEnded += new EventHandler(BackgroundMusic_Ended);
        //Start the music playing
        _backgroundMusic.Play();
    }
