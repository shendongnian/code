    [AddINotifyPropertyChangedInterface]
    public class WordsViewModel
    {
        public ObservableCollection<WordItem> _FCsource;
        public ObservableCollection<WordItem> FCsource { get { return AddFlashCard(); } set { FCsource = value; } }
        private WordItem _SelectedItem;
        public WordItem SelectedItem
        {
            get => _SelectedItem; set
            {
                _SelectedItem = value;
                if (_SelectedItem != null)
                {
                    SelectedItem.Words = "hello";
                }
            }
        }
        public WordsViewModel()
        {
            AddFlashCard();
        }
        private ObservableCollection<WordItem> AddFlashCard()
        {
            ObservableCollection<WordItem> listmn = new ObservableCollection<WordItem>();
            listmn.Add(new WordItem("qwda"));
            listmn.Add(new WordItem("qwda"));
            listmn.Add(new WordItem("qwda"));
            return listmn;
        }
    }
    [AddINotifyPropertyChangedInterface]
    public class WordItem
    {
        public string Words { get; set; }
        public WordItem(string words)
        {
            Words = words;
        }
    }
