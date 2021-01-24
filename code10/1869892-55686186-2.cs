     private bool _IsVisible;
       public bool IsVisible
         {
           get { return _IsVisible; }
           set { _IsVisible = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsVisible")); }
         } 
 
