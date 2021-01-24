    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        MusicBack.instance.musicSource.volume = 1f;
        MusicBack.instance.efxSource.volume   = MusicBack.instance.efxSourceEnemy.volume = 1f;
    }
    
    public void SetVolume(float vol) { MusicBack.instance.musicSource.volume = 1f; }
    
    public void SetVolumeFx(float vol2)
    {
        MusicBack.instance.efxSource.volume = MusicBack.instance.efxSourceEnemy.volume = vol2;
    }
