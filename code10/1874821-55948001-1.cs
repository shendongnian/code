    public sealed partial class MainPage : Page
    {
        public ObservableCollection<SongGroup> Groups2 { get; set; }
        private Song _SelectedSong;
        public Song SelectedSong
        {
            get { return _SelectedSong; }
            set
            {
                _SelectedSong = value;
            }
        }
        public MainPage()
        {
            this.InitializeComponent();
            Groups2 = GenerateData();
            this.DataContext = this;
        }
        private ObservableCollection<SongGroup> GenerateData()
        {
            ObservableCollection<SongGroup> songGroups = new ObservableCollection<SongGroup>();
            ObservableCollection<Song> songs = new ObservableCollection<Song>();
            songs.Add(new Song() { Title = "Song1" });
            songs.Add(new Song() { Title = "Song2" });
            songGroups.Add(new SongGroup() { Key = "A", Items = songs });
            ObservableCollection<Song> songs2 = new ObservableCollection<Song>();
            songs2.Add(new Song() { Title = "Song2_1" });
            songs2.Add(new Song() { Title = "Song2_2" });
            songGroups.Add(new SongGroup() { Key = "B", Items = songs2 });
            return songGroups;
        }
        private void ItemGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var song = e.ClickedItem;
        }
    }
    public class Song
    {
        public string Title { get; set; }
    }
    public class SongGroup
    {
        public string Key { get; set; }
        public ObservableCollection<Song> Items { get; set; }
    }
