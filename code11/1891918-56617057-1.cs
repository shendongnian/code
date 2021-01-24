    foreach (string s in filesList)
    {
        string newS = s.Replace(path, "");
        string[] splitted = s.Split(@"!@=-@!"); //this is the separator I used between the artist's name and the song's name
         //Here  splitted[0] is artist name and splitted[1] is song name
         //Then
         var existingArtist = artistList.FirstOrDefault(x => x.Name == splitted[0]);
         //^^^ FirstOrDefault clause while give you instance of Artist based on condition/predicate
       
        //Null check for checking Artist is already exist in list or not.
        if(existingArtist != null)
           existingArtist.songs.Add(splitted[1])
        else
        {
            Artist artist = new Artist();
            artist.name = splitted[0];
            artist.songs.Add(splitted[1]);
            artistList.Add(artist); //Bonus : This was missing in your code
            //if it doesn't contain, add a new artist to the list
        }
    }
