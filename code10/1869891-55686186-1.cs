       private bool _IsVisible;
            public bool IsVisible
            {
                get { return _IsVisible; }
                set { _IsVisible = value; this.OnPropertyChanged("IsVisible"); }
            }
  
     public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
    
                 Views.Select(n =>
                {
                    if (n.ViewName.ToLower().Contains(searchText.ToLower()))
                    {
                        n.IsVisible = true;
                    }
                    else
                    {
                        n.IsVisible = false;
                    }
                    return n;
                }).ToList();
    
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Views"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SearchText"));
            }
        }
