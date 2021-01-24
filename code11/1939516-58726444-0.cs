c#
private async void PlayPlaylist(string value)
{
    if (PlayButtonMode == 1)
    {
        int startPosition;
        //Playing playlist from selected item if user selected one. (first item if he didn't)
        if (PlaylistSelectedItem == null) startPosition = 0;
        else startPosition = Playlist.IndexOf(playlistSelectedItem);
        if (audio.IsPlaying) audio.Stop();
        PlaylistSelectedItem = Playlist[startPosition];
        audio.Load(GetStreamFromFile(PlaylistSelectedItem.Name + ".wav"));
        audio.Play();
        audio.PlaybackEnded += Audio_PlaybackEnded;
    }
    else if (PlayButtonMode == 2)
        audio.Play();
    else
    {
        if (audio.IsPlaying) audio.Pause();
    }
    ChangeButtonMode(PlayButtonMode);
}
private void ChangeButtonMode(int senderMode)
{
    if (senderMode == 1 || senderMode == 2)
    {
        PlayButtonText = "PAUSE";
        PlayButtonImage = "pause_icon.png";
        PlayButtonMode = 0;
    }
    else
    {
        PlayButtonText = "PLAY";
        PlayButtonImage = "play_icon.png";
        if (senderMode == 3) PlayButtonMode = 1; 
        else PlayButtonMode = 2;
    }
    NotifyButtonChange();
}
private void Audio_PlaybackEnded(object sender, EventArgs e)
{
    //Check if next playlist element exists
    if(Playlist.IndexOf(PlaylistSelectedItem) + 1 < Playlist.Count)
    {
        PlaylistSelectedItem = Playlist[Playlist.IndexOf(PlaylistSelectedItem) + 1];
        if (audio.IsPlaying) audio.Stop();
        audio.Load(GetStreamFromFile(PlaylistSelectedItem.Name + ".wav"));
        audio.Play();
        audio.PlaybackEnded += Audio_PlaybackEnded;
    }else if(audio.IsPlaying) audio.Stop();   
}
private void StopAudio()
{
    if (audio.IsPlaying)
        audio.Stop();
    ChangeButtonMode(3);
}
