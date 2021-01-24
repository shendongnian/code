     public class Result: INotifyPropertyChanged
    {
        public int id { get; set; }
        public string country { get; set; }
        public string name { get; set; }
        //Note: If you want to change any thing without reload cells, use this type and inherit 'INotifyPropertyChanged'
        // Example: Favourite and UnFavourite button action, tapping any event change any text from cell
        public string abbr {
            get { return _abbr; } 
            set { _abbr = value;  OnPropertyChanged("abbr"); }
        }
        public string area { get; set; }
        public string largest_city { get; set; }
        public string capital { get; set; }
        public bool isFavourite 
        { 
            get { return _fav; }
            set { 
                   _fav = value; OnPropertyChanged("isFavourite");
                }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public bool _fav;
        public string _abbr;
        
        private void OnPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
    }
