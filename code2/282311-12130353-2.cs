    container.Register(Component.For<SearchCommand>());
    container.Register(Component.For<ShowOptionsCommand>());
    container.Register(Component.For<MainWindowViewModel>().OnCreate(new Action<MainWindowViewModel>(p => p.SetUpCommands())));
    public class MainWindowViewModel
    {
        public ShowOptionsCommand ShowOptions { get; set; }
        public SearchCommand Search { get; set; }
        public MainWindowViewModel()
        {
        }
        public void SetUpCommands()
        {
            this.ShowOptions.Host = this;
            this.Search.Host = this;
        }
    }
