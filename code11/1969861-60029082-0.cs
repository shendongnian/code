        class MainWindowViewModel : BaseViewModel
    {
        public static ObservableCollection<string> SystemList { get; set; } = new ObservableCollection<string>();
        //--------------------------------------------------------------------------------------------//
        public static ObservableCollection<string> TitleList { get; set; } = new ObservableCollection<string>();
        //--------------------------------------------------------------------------------------------//
        public static ObservableCollection<string> RevisionList { get; set; } = new ObservableCollection<string>();
        //--------------------------------------------------------------------------------------------//
        public static ObservableCollection<DocumentModel> DocumentList { get; set; } = new ObservableCollection<DocumentModel>();
        //--------------------------------------------------------------------------------------------//
        public static string SystemFilter { get; set; } = String.Empty;
        //--------------------------------------------------------------------------------------------//
