    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Films = new ObservableCollection<Film>(LoadFilms());
            this.DataContext = this;
        }
        private static IEnumerable<Film> LoadFilms()
        {
            string imagesDirectory = @"D:\Docs\DVD\covers";
            return
                from file in Directory.EnumerateFiles(imagesDirectory)
                select new Film
                    {
                        Title = Path.GetFileNameWithoutExtension(file),
                        ImagePath = file
                    };
        }
        public ObservableCollection<Film> Films { get; private set; }
    }
