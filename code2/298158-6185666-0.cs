    [XmlRootAttribute("playlist", Namespace = "", IsNullable = false)]
    public class PlaylistResponse 
    {
    	public int id;
    	public string title;
    	public string description;
    
    	[XmlArray]
    	[XmlArrayItem(typeof(PlaylistResponse), ElementName = "playlist")]
    	public PlaylistResponse[] childPlaylists;
    }
    
    XmlReader reader = XmlReader.Create(new StringReader(xml)); // your xml above
    XmlSerializer serializer = new XmlSerializer(typeof(PlaylistResponse));
    PlaylistResponse response = (PlaylistResponse)serializer.Deserialize(reader);
    int count = response.childPlaylists.Length; // 4
