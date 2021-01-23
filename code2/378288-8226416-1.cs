    private void songList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        Controls.ListBox songList = sender as Controls.ListBox;
        if (songList.SelectedItems.Count > 0)
        {
            Song selectedSong = songList.SelectedItems[0];
            
            // To be on the safe side
            if (InternalSongList.Contains(selectedSong))
            {
                selectedSong.Play();
            }
        }
    }
