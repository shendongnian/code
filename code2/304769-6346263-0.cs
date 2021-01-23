    public class myViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> MyItems { get; set; }
    
        public bool IsLoading { get; set; } // make this implement NotifyPropertyChanged when set
    
        public void LoadData()
        {
            this.IsLoading = true;
    
            for(var i = 0; i < 1000; i++)
            {
                this.MyItems.Add(i);
            }
    
            this.IsLoading = false;
        }
    }
