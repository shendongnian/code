    public class MainWindowViewModel : BindableBase
    {
        public QueryResults QueryResults { get; }
        public MainWindowViewModel(QueryResults queryResults)
        {
            QueryResults = queryResults;
        }
        private DelegateCommand _showPopupCommand;
        public DelegateCommand ShowPopupCommand =>
            _showPopupCommand ?? (_showPopupCommand = new DelegateCommand(ExecuteShowPopupCommand));
        void ExecuteShowPopupCommand()
        {
            var popupViewModel = new PopupViewModel(QueryResults);
            var popupWindow = new PopupWindow { DataContext = popupViewModel };
            popupWindow.Show();
        }
    }
