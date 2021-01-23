    [XmlRoot("playlist")] 
    public class PlaylistResponse : Response
    {
        public int id;
        public string title;
        public string description;
        [XmlArrayItem("playList")]
        public List<PlaylistResponse> childPlaylists;
    }
