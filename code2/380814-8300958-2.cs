    int[] songIDs = ((ArrayList)Session["SelectedSongs"]).OfType<int>().ToArray();
    var query = from s in sa.Songs
                where songIDs.Contains(s.SongID)
                select new 
                { 
                  s.SongID, 
                  s.SongName, 
                  s.Artist.ArtistName, 
                  s.Genre.GenreName 
                };
