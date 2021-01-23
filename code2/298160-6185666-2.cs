    [XmlRootAttribute("playlist")]
    public class PlaylistResponse 
    {
    	public int id;
    	public string title;
    	public string description;
    
        [XmlArray(ElementName="childPlaylists")]
        [XmlArrayItem(typeof(PlaylistResponse), ElementName="playlist")]
        public PlaylistResponse[] ChildPlaylists;
    }
    
    XmlReader reader = XmlReader.Create(new StringReader(xml)); // your xml above
    XmlSerializer serializer = new XmlSerializer(typeof(PlaylistResponse));
    PlaylistResponse response = (PlaylistResponse)serializer.Deserialize(reader);
    int count = response.ChildPlaylists.Length; // 4
