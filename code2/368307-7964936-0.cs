       public bool IsFavourite 
       {
           get { .. }
           set {
             ...
             RaisePropertyChanged("IsFavourite"); 
             RaisePropertyChanged("MemoryUsageLevel"); 
           }  
       } 
