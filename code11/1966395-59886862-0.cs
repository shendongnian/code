public partial class GamesPage : Page
    {
        RareMantisEntities1 _db = new RareMantisEntities1();
        public static DataGrid datagrid;
        public GamesPage()
        {
            InitializeComponent();
            Load();
        }
        private void Load()
        {
            dg_Games.ItemsSource = _db.Games.ToList();
            datagrid = dg_Games;
        }
    }
