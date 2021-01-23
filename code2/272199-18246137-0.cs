    <Query Kind="Program">
      <Namespace>iTunesLib</Namespace>
      <Namespace>System.Security.Cryptography</Namespace>
    </Query>
    void Main()
    {
      var track = new iTunesApp().CurrentTrack;
      
      if (track == null)
        "nothing playing".Dump();
      else
        new Viewer(track,true).Dump();
    }
    
    public class Viewer
    {
      const string PREFIX = "itlps-";
    
      private IITFileOrCDTrack store;
      private bool materialize;
      
      public string album { get { return store.Album; } }
      public string band { get { return store.Artist; } }
      public string song { get { return store.Name; } }
      public string desc { get { return store.Description; } }
      public int? artCnt { get {
        if (store.Artwork == null) return null;
        else return store.Artwork.Count; }
      }
      
      public IEnumerable<ImageViewer> art { get {
      
        if (materialize)
        {
          foreach(var artT in store.Artwork)
          {
            var art = artT as IITArtwork;
            string ext = ".tmp";
            switch(art.Format)
            {
              case ITArtworkFormat.ITArtworkFormatBMP:
                ext = ".BMP";
                break;
              case ITArtworkFormat.ITArtworkFormatJPEG:
                ext = ".JPG";
                break;
              case ITArtworkFormat.ITArtworkFormatPNG:
                ext = ".PNG";
                break;
            }
         
            string path = Path.Combine(Path.GetTempPath(),PREFIX+Path.GetRandomFileName()+ext);
         
            art.SaveArtworkToFile(path);
         
            yield return new ImageViewer(path);
          }
        }
        yield break; }
      }
    
      public Viewer(IITFileOrCDTrack t,bool materializeArt = false)
      {
        store = t;
        materialize = materializeArt;
      }
      
      public Viewer(IITTrack t,bool materializeArt = false)
      {
        store = t as IITFileOrCDTrack;
        materialize = materializeArt;
      }
      
    }
    
    public class ImageViewer
    {
      public string hash { get { return _hash.Value; } }
      static private string _path { get; set; }
      public object image { get { return _image.Value; } }
    
      static private SHA1Managed sha = new SHA1Managed();  
      private Lazy<object> _image = new Lazy<object>(() => {return Util.Image(_path);});
      private Lazy<string> _hash = new Lazy<string>(() =>
      {
        string hash = string.Empty;
        using (FileStream stream = File.OpenRead(_path))
        {
          byte [] checksum = sha.ComputeHash(stream);
          hash = BitConverter.ToString(checksum).Replace("-", string.Empty);
        }  
        return hash;
      });
    
      public ImageViewer(string path)
      {
        _path = path;
      }
    }
