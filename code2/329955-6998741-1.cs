    class NestedTypeViewModel 
    {     
        private ObservableCollection<NestedType> dataItems; 
    
        public ObservableCollection<NestedType> DataItems
        {
           get
           { 
              return this.dataItems;
           }
           private set
           {
               this.dataItems = value;
               // here is should be OnPropertyChanged("DataItems") call
           }
        } 
    } 
