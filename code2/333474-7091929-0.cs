    public sealed class Album
    {
      public string Name {get;set;}
      public string Artist {get;set;}
      public IEnumerable<Song> Songs {get;set;}
    }
    public sealed class Song
    {
      public string Name {get;set;}
      public TimeSpan Length {get;set;}
    }
