    using (var ml = new MediaLibrary())
    {
      foreach (var song in ml.Songs)
      {
          System.Diagnostics.Debug.WriteLine(song.Artist + " " + song.Name);
          MessageBox.Show(song.Artist + " " + song.Name);
      }
      FrameworkDispatcher.Update();
      MediaPlayer.Play(ml.Songs[0]);
    }
