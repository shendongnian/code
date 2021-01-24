    public class Song
    {
        public string name
        {
            get;
            set;
        }
    }
    public class Album
    {
        public string name
        {
            get;
            set;
        }
        public List<Song> Songs
        {
            get;
            set;
        }
        public Album(string name)
        {
            this.name = name;
            Songs = new List<Song>() { new Song { name = this.name+ " Song 1" }, new Song { name = this.name + " Song 2" } };
        }
    }
    public class AlbumViewModel
    {
        public List<Album> Albums
        {
            get;
            set;
        } = new List<Album>();
        public AlbumViewModel()
        {
            Albums.Add(new Album("Album 1"));
            Albums.Add(new Album("Album 2"));
            Albums.Add(new Album("Album 3"));
            Albums.Add(new Album("Album 4"));
        }
        public Album Selected
        {
            get;
            set;
        }
    }
