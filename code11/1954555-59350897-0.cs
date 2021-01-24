    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Game selectedGame = e.SelectedItem as Game;
            var currentVm = this.BindingContext as GameListViewModel;
            currentVm.InsertGame(selectedGame);
        }
    }
