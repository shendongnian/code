    public HeaderViewModel : BindableObject {
        public Header Header { get; set; }
    
        private ObservableCollection<Detail> details { get; set; }
        public ObservableCollection<Detail> Details { 
            get => details;
            set {
                details = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ButtonBackgroundColor);
            }
        }
    
        public Color ButtonBackgroundColor {
            get {
                if (Details.Count == 0) return Color.Blue;
                if (Details.Any(d => !d.Complete) return Color.Orange;
                return Color.Green;
            }
        }
    
        public HeaderViewModel(Header header) {
            this.Header = header;
            this.Details = SelectAllDetailItemsForWithThisHeaderId() //Your query that does what the name tells
        }
    }
