     private void PlayNextSong()
        {
    
          Song song = Song.FromUri(activesong.Name, new Uri("test" + i.ToString() + ".mp3", UriKind.Relative));
          MediaPlayer.Play(song);
          i++;
          FrameworkDispatcher.Update();
        }
    
    private void button1_Click(object sender, RoutedEventArgs e)
        {
          PlayNewSong();
        }
