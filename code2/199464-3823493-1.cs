    public partial class Window1 : Window
    {
      private ObservableCollection<VideoGame> _games =
        new ObservableCollection<VideoGame>();
    
      public ObservableCollection<VideoGame> Games
      {
        get { return _games; }
      }
    
      public Window1()
      {
        _games.Add(new VideoGame() {
          Name = "Crysis",
          Image = @"C:\Crysis_Boxart_Final.jpg" });
        _games.Add(new VideoGame() {
          Name = "Unreal Tournament 3",
          Image = @"C:\Gearsofwar.JPG" });
        _games.Add(new VideoGame() {
          Name = "Gears of War",
          Image = @"C:\Crysis_Boxart_Final.jpg" });
    
        InitializeComponent();
      }
    }
