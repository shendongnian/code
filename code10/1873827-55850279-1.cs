    public class CabinViewViewModel : BindableBase, ICabinViewViewModel
    {
        private bool _showButtons;
        public bool ShowButtons
        {
            get { return _showButtons; }
            set { SetProperty(ref _showButtons, value); }
        }
        ...
    }
