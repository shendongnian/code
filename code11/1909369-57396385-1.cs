    public class MainWindowViewModel : BindableBase
    {
        public QueryResults QueryResults { get; }
        public MainWindowViewModel(QueryResults queryResults)
        {
            QueryResults = queryResults;
        }
    }
    public class PopupViewModel : BindableBase
    {
        public QueryResults QueryResults { get; }
        public PopupViewModel(QueryResults queryResults)
        {
            QueryResults = queryResults;
        }
    }
