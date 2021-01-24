    public class MenuViewModel : ReactiveObject
    {
        public ReactiveCommand<Unit, IOverlayViewModel> NavigateCommand { get; }
    }
    public class MainViewModel : ReactiveObject
    {
        public MainViewModel()
        {
            MenuVM.NavigateCommand.Subscribe(viewModel => OverlayVM = viewModel);
        }
        public MenuViewModel MenuVM { get; set; } = new MenuViewModel();
        [Reactive] IOverlayViewModel OverlayVM { get; set; }
    }
