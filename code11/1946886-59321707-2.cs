    private static void BackgroundMusic_Ended(object sender, EventArgs e){
        //Set the music back to the beginning
        _backgroundMusic.Position = TimeSpan.Zro;
        //Play the music
        _backgroundMusic.Play();
    }
