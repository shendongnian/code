    public SermonDetailViewModel(Sermon sermon = null)
    {
        if (sermon != null)
        {
            Title = sermon.STitle;
            MP3Filepath = sermon.SLink;
            PlayCommand = new Command(async () => await StartPlayer());
            PlayImage= "play.png";
        }
        Sermon = sermon;
    }
    async Task StartPlayer()
    { 
        await CrossMediaManager.Current.Play(MP3Filepath);
        PlayImage= "pause.png";
        Console.WriteLine(_playImage);
        Console.WriteLine(PlayImage);
    }
